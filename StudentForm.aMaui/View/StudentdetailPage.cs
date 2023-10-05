using BackEnd;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentForm.aMaui.View;

public class StudentDetailPage : ContentPage
{
    public ObservableCollection<string[]> StudentList { get; set; }
    private DateTime lastTapTime = DateTime.MinValue;
    private TableView tableView; 
    CollectionView collectionView;
    SearchBar searchBar;
    private string currentSortColumn = "FirstName"; 
    private bool isAscending = true; 
    BackEnd.Layout layout=new BackEnd.Layout();
    public StudentDetailPage()
	{
        StudentList = new ObservableCollection<string[]>();
        addDefaultStudent();
        var addButton = new ToolbarItem
        {
            Text = "+Add",

        };
        addButton.Clicked += AddButton_Clicked;

        ToolbarItems.Add(addButton);
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

        Title = layout.OurStudenHeader;

        var searchBar = new SearchBar
        {
            Placeholder = "Search...",
            WidthRequest = 350,
        };

        searchBar.TextChanged += SearchBar_TextChanged;


        collectionView = new CollectionView();


        // StackLayout to organize the elements vertically
        var mainLayout = new ScrollView
        {
            Content = new StackLayout
            {
                Padding = new Thickness(15),
                Children = { searchBar,  collectionView }
            }
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
        collectionView.ItemsSource = students;
        collectionView.ItemTemplate = new DataTemplate(() =>
        {
            // Create a grid for each item
            var grid = new Grid();
            
            // Define rows and columns
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            grid.ColumnSpacing = 5;
            grid.RowSpacing = 10;
            
            // Bind data to labels and set row/column positions
            var idLabel = new Label();
            idLabel.SetBinding(Label.TextProperty, new Binding("[0]"));
            idLabel.IsVisible = false;

            var firstNameLabel = new Label
            {
                FormattedText = new FormattedString
                {
                Spans =
                {
                    new Span { Text = "" },
                     new Span { Text = " " },
                    new Span { Text = "", } 
                },

                },
                Margin = new Thickness(0, 4, 0, 4),
                FontSize = layout.fontSize * 0.9
            };
            Grid.SetColumn(firstNameLabel, 0);
            Grid.SetRow(firstNameLabel, 0);
            Grid.SetColumnSpan(firstNameLabel, 2);

            // Set bindings to the Text property of the Spans
            var firstNameBinding = new Binding("[1]");
            firstNameLabel.FormattedText.Spans[0].SetBinding(Span.TextProperty, firstNameBinding);

            var starsBinding = new Binding("[2]");
            firstNameLabel.FormattedText.Spans[2].SetBinding(Span.TextProperty, starsBinding);



            var genderLabel = new Label();
            genderLabel.SetBinding(Label.TextProperty, new Binding("[3]"));
            Grid.SetColumn(genderLabel, 0);
            Grid.SetRow(genderLabel, 1);

            var ageLabel = new Label();
            ageLabel.SetBinding(Label.TextProperty, new Binding("[4]"));
            Grid.SetColumn(ageLabel, 3);
            Grid.SetRow(ageLabel, 0);

            var classLabel = new Label();
            classLabel.SetBinding(Label.TextProperty, new Binding("[5]"));
            Grid.SetColumn(classLabel, 3);
            Grid.SetRow(classLabel, 1);

            
            // Add data labels to grid
            grid.Children.Add(idLabel);
            grid.Children.Add(firstNameLabel);
            grid.Children.Add(genderLabel);
            grid.Children.Add(ageLabel);
            grid.Children.Add(classLabel);

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (sender, e) =>
            {
                    HandleDoubleTap(idLabel.Text);
            };
            grid.GestureRecognizers.Add(tapGesture);

            Border CollectionBorder = new Border
            {
                StrokeThickness = 2,
                Padding = new Thickness(7),
                Margin = new Thickness(7,2),
                WidthRequest = 350,
                HeightRequest = 80,
                BackgroundColor = Color.FromArgb("#f0f8ff"),
                HorizontalOptions = LayoutOptions.Center,
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(10)
                },
                Content = grid
            };

            return new ContentView { Content = CollectionBorder,HorizontalOptions = LayoutOptions.Center,VerticalOptions=LayoutOptions.Center, Margin=new Thickness(4,2) };
        });
    }
 
}


