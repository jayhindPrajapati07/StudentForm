using BackEnd;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentForm.aMaui.View;

public class StudentDetailPage : ContentPage
{
    public ObservableCollection<string[]> StudentList { get; set; }
    private DateTime lastTapTime = DateTime.MinValue;
    private TableView tableView; 
    private TableSection tableSection; 
    SearchBar searchBar;
    private string currentSortColumn = "FirstName"; 
    private bool isAscending = true; 
    BackEnd.Layout layout=new BackEnd.Layout();
    public StudentDetailPage()
	{
        StudentList = new ObservableCollection<string[]>();
        addDefaultStudent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        StudentList.Clear();
        //Populate the StudentList with data from DataLayer
        foreach (var student in DataLayer.studentList)
        {
            StudentList.Add(student);
        }
        //FilteredStudent = StudentList;
        
        InitializeComponent();
        RefreshStudentList(DataLayer.studentList);
    }

    private void InitializeComponent()
    {
        // Header Label
        var headerLabel = new Label
        {
            Text = layout.OurStudenHeader,
            FontSize = layout.fontSize*1.5,
            Margin = new Thickness(0,0,0,10),
            HorizontalOptions = LayoutOptions.Center
        };

        // Search Box and Button (same as before)
        searchBar = new SearchBar
        {
            Placeholder = "Search...",
            WidthRequest = 200,
        };
        searchBar.TextChanged += SearchBar_TextChanged;
        var addButton = new Button
        {
            Text = layout.addBtnText,
            WidthRequest = 72,
            Margin = new Thickness(20, 0, 0, 0)

        };
        addButton.Clicked += AddButton_Clicked;

        var searchLayout = new StackLayout
        {
            WidthRequest = 330,
            Orientation = StackOrientation.Horizontal,

            Children = { searchBar, addButton }
        };

        

        // Table Section starts ---
        tableSection = new TableSection("")
        {
            //data added below
        };

        tableView = new TableView
        {
            //BackgroundColor = Color.FromArgb("#f7f0f6"),
            Margin = new Thickness(5, 30),
            Root = new TableRoot
            {
                new TableSection
                {
                    new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 2,
                            Children =
                            {
                                CreateColumnHeaderLabel(layout.FirstNameColumnHeader, "FirstName"),
                                CreateColumnHeaderLabel(layout.LastNameColumnHeader, "LastName"),
                                CreateColumnHeaderLabel(layout.GenderCoumnHeader, "Gender"),
                                CreateColumnHeaderLabel(layout.AgeColumnHeader, "Age"),
                                CreateColumnHeaderLabel(layout.ClassColumnHeader, "Class"),
                            }
                        }
                    }
                }
                ,
                tableSection
            }
        };
        Border TableLayout = new Border
        {
            StrokeThickness = 3,
            Padding = new Thickness(10, 5),
            Margin=new Thickness(0, 20),
            HorizontalOptions = LayoutOptions.Center,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(10)
            },
            Content = tableView
        };


        // StackLayout to organize the elements vertically
        var mainLayout = new StackLayout
        {
            Padding = new Thickness(15),
            Children = { headerLabel, searchLayout, TableLayout }
        };

        Content = mainLayout;
    }

    
    //Default Data
    private static bool defaultStudentAdded = false;
    DataLayer dataLayer = new DataLayer();
    void addDefaultStudent()
    {
        if (!defaultStudentAdded)
        {
            dataLayer.defaultStudents();
            defaultStudentAdded = true;
        }
    }
    private void HandleDoubleTap(string studentId)
    {
        Shell.Current.GoToAsync($"{nameof(AddEditPage)}?Id={studentId}&EditMode=true");
    }
    private Label CreateColumnHeaderLabel(string text, string columnName)
    {
        var label = new Label
        {
            Text = text,
            FontSize=layout.fontSize*.8,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.StartAndExpand
        };

        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += (sender, e) =>
        {
            SortByColumn(columnName);
        };
        label.GestureRecognizers.Add(tapGesture);

        return label;
    }


    private void AddButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddEditPage));
    }

    
    //For Searching
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue;

        if (string.IsNullOrWhiteSpace(searchText))
        {
            RefreshStudentList(DataLayer.studentList);
        }
        else
        {
            // Filter the students based on the search text.
            var filteredStudents = StudentList
                .Where(student => student[1].Contains(searchText, StringComparison.OrdinalIgnoreCase) ||  // First Name
                                  student[2].Contains(searchText, StringComparison.OrdinalIgnoreCase) ||  // Last Name
                                  student[4].Split(" ")[0].Contains(searchText, StringComparison.OrdinalIgnoreCase))    // Gender
                .ToList();

            RefreshStudentList(filteredStudents);
        }
    }

    //For Shorting
    private void SortByColumn(string columnName)
    {
        if (currentSortColumn == columnName)
        {
            isAscending = !isAscending;
        }
        else
        {
            // Reset the sorting order if clicking a different column
            currentSortColumn = columnName;
            isAscending = true;
        }

        // Sort the StudentList based on the selected column and order
        List<string[]> sortedStudents;
        switch (columnName)
        {
            case "FirstName":
                sortedStudents = isAscending ? StudentList.OrderBy(student => student[1]).ToList() :
                                               StudentList.OrderByDescending(student => student[1]).ToList();
                break;
            case "LastName":
                sortedStudents = isAscending ? StudentList.OrderBy(student => student[2]).ToList() :
                                               StudentList.OrderByDescending(student => student[2]).ToList();
                break;
            case "Gender":
                sortedStudents = isAscending ? StudentList.OrderBy(student => student[3]).ToList() :
                                               StudentList.OrderByDescending(student => student[3]).ToList();
                break;
            case "Age":
                sortedStudents = isAscending ? StudentList.OrderBy(student => int.Parse(student[4].Split(" ")[0])).ToList() :
                                               StudentList.OrderByDescending(student => int.Parse(student[4].Split(" ")[0])).ToList();
                break;
            case "Class":
                sortedStudents = isAscending ? StudentList.OrderBy(student => student[5]).ToList() :
                                               StudentList.OrderByDescending(student => student[5]).ToList();
                break;
            default:
                sortedStudents = DataLayer.studentList; 
                break;
        }

        // Refresh the student list with the sorted data
        RefreshStudentList(sortedStudents);
    }


    private void RefreshStudentList(List<string[]> students)
    {
        // Clear the current tableSection and add the filtered students.
        tableSection.Clear();

        foreach (var student in students)
        {
            var id = student[0];

            var viewCell = new ViewCell
            {
                View = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 2,
                    Children =
                    {
                        new Label { HorizontalOptions = LayoutOptions.StartAndExpand, Text = student[1] ,FontSize=layout.fontSize*.7},
                        new Label { HorizontalOptions = LayoutOptions.StartAndExpand, Text = student[2] ,FontSize=layout.fontSize*.7},
                        new Label { HorizontalOptions = LayoutOptions.StartAndExpand, Text = student[3] ,FontSize=layout.fontSize*.7},
                        new Label { HorizontalOptions = LayoutOptions.StartAndExpand, Text = student[4] ,FontSize=layout.fontSize*.7},
                        new Label { HorizontalOptions = LayoutOptions.StartAndExpand, Text = student[5] ,FontSize=layout.fontSize*.7},
                    }
                }
            };

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (sender, e) =>
            {
                TimeSpan timeSinceLastTap = DateTime.Now - lastTapTime;
                if (timeSinceLastTap.TotalMilliseconds < 300) // Adjust the time threshold as needed
                {
                    HandleDoubleTap(id);
                }
                lastTapTime = DateTime.Now;

            };
            viewCell.View.GestureRecognizers.Add(tapGesture);
            tableSection.Add(viewCell);
        }
    }

    
}


