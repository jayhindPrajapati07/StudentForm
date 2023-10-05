namespace StudentForm.aMaui.View;
using BackEnd;
using Microsoft.Maui.Controls;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

[QueryProperty(nameof(StudentId), "Id")]
[QueryProperty(nameof(IsEditMode), "EditMode")]
public class AddEditPage : ContentPage
{
    public string StudentId { get; set; }
    public string IsEditMode { get; set; } 
    private Entry firstNameEntry;
    private Entry lastNameEntry;
    private Picker genderPicker;
    private DatePicker dateOfBirthDatePicker;
    private Entry ageEntry;
    private Entry classEntry;
    private Editor addressEntry;
    private Button deleteButton;

    private Label lblfnameError;
    private Label lbllnameError;
    private Label lblgenderError;
    private Label lblDateOfBirthError;
    private Label lblageError;

    StudentModel studentModel = new StudentModel();
    BackEnd.Layout layout=new BackEnd.Layout();
    public AddEditPage()
	{
        InitializeComponent();
        var saveButton = new ToolbarItem
        {
            Text = "Save",

        };
        ToolbarItems.Add(saveButton);
        saveButton.Clicked += SaveButton_Clicked;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        if (IsEditMode == "true")
        {
            getSelectedStudentData(int.Parse(StudentId));
            Title = layout.EditStudentHeader;
        }
        else
        {
            deleteButton.IsVisible= false;
            Title = layout.AddStudentHeader;
        }
        
    }
    private void getSelectedStudentData(int Id)
    {
        DataLayer data = new DataLayer();
        int id = data.getStudentById(Id);
        if (id >= 0)
        {
            string[] selectedStudent = DataLayer.studentList[id];
            firstNameEntry.Text = selectedStudent[1];
            lastNameEntry.Text = selectedStudent[2];
            genderPicker.SelectedIndex = int.Parse(selectedStudent[8]);
            string age = selectedStudent[4];
            age = age.Split(" ")[0];
            ageEntry.Text = age;
            dateOfBirthDatePicker.Date = Convert.ToDateTime(selectedStudent[7]);
            classEntry.Text = selectedStudent[5];
            addressEntry.Text = selectedStudent[6];
        }

    }
    private void InitializeComponent()
    {
        Title = layout.AddStudentHeader;
        
        //First Name
        var firstNameLabel = new Label
        {
            FormattedText = new FormattedString
            {
                Spans ={
                    new Span{Text=layout.FirstNameLabel,},
                    new Span{Text=layout.stars,TextColor=Color.FromArgb("f00")}
                }
            },
            Margin = new Thickness(20, 4, 0, 4),
            FontSize = layout.fontSize * .9
        };

        var firstNameEntryFrame = new Frame
        {
            HeightRequest = 50
        };

        firstNameEntry = new Entry
        {
            HeightRequest = 50,
            FontSize = layout.fontSize * .9,
            Placeholder = "Please enter First Name",
            MaxLength = 50,
        };
        firstNameEntry.TextChanged += FirstNameEntry_TextChanged;
        firstNameEntryFrame.Content = firstNameEntry;
        //Last Name
        var lastNameLabel = new Label
        {
            FormattedText = new FormattedString
            {
                Spans ={
                    new Span{Text=layout.LastNameLabel,},
                    new Span{Text=layout.stars,TextColor=Color.FromArgb("f00")}
                }
            },
            Margin = new Thickness(20, 4, 0, 4),
            FontSize = layout.fontSize * .9,
        };

        var lastNameEntryFrame = new Frame
        {
            HeightRequest = 50
        };

        lastNameEntry = new Entry
        {
            HeightRequest = 50,
            FontSize = layout.fontSize * .9,
            Placeholder = "Please enter Last Name",
            MaxLength = 50,
        };
        lastNameEntry.TextChanged += LastNameEntry_TextChanged;
        lastNameEntryFrame.Content = lastNameEntry;
        //Gender
        var genderLabel = new Label
        {
            FormattedText = new FormattedString
            {
                Spans ={
                    new Span{Text=layout.GenderLabel},
                    new Span{Text=layout.stars,TextColor=Color.FromArgb("f00")}
                }
            },
            Margin = new Thickness(20, 4, 0, 4),
            FontSize = layout.fontSize * .9,
        };

        var genderPickerFrame = new Frame
        {
            HeightRequest = 50
        };

        genderPicker = new Picker
        {
            HeightRequest = 50,
            FontSize = layout.fontSize * .9,
            Title = "Select Gender"
        };

        genderPicker.ItemsSource = new string[] { "Male", "Female" };
        genderPickerFrame.Content = genderPicker;
        //DateOfBirth
        var dateOfBirthLabel = new Label
        {
            FormattedText = new FormattedString
            {
                Spans ={
                    new Span{Text=layout.DateOfBirthLabel,},
                    new Span{Text=layout.stars,TextColor=Color.FromArgb("f00")}
                }
            },
            Margin = new Thickness(20, 0, 0, 0),
            FontSize = layout.fontSize * .9,
        };

        var dateOfBirthFrame = new Frame
        {
            HeightRequest = 50
        };

        dateOfBirthDatePicker = new DatePicker
        {
            FontSize = layout.fontSize * .9,
            HeightRequest = 50,
            MaximumDate = DateTime.Today,
            MinimumDate = DateTime.Now.AddYears(-100),
            VerticalOptions = LayoutOptions.Center,
            AutomationId = "DateOfBirthPicker"

        };
        dateOfBirthDatePicker.DateSelected += DateOfBirthDatePicker_DateSelected;

        dateOfBirthFrame.Content = dateOfBirthDatePicker;
        //Age
        var ageLabel = new Label
        {
            FormattedText = new FormattedString
            {
                Spans ={
                    new Span{Text=layout.AgeLabel,},
                    new Span{Text=layout.stars,TextColor=Color.FromArgb("f00")}
                }
            },
            Margin = new Thickness(20, 4, 0, 4),
            FontSize = layout.fontSize * .9,
        };

        var ageEntryFrame = new Frame
        {
            HeightRequest = 50
        };

        ageEntry = new Entry
        {
            HeightRequest = 50,
            FontSize = layout.fontSize * .9,
            MaxLength = 2
        };
        ageEntry.TextChanged += AgeEntry_TextChanged;

        ageEntryFrame.Content = ageEntry;
        //Class
        var classLabel = new Label
        {
            Margin = new Thickness(20, 4, 0, 4),
            Text = layout.ClassLabel,
            FontSize = layout.fontSize * .9,
        };

        var classEntryFrame = new Frame
        {
            HeightRequest = 50
        };

        classEntry = new Entry
        {
            HeightRequest = 50,
            FontSize = layout.fontSize * .9,
            Placeholder = "Please enter Class",
            MaxLength = 50,
        };

        classEntryFrame.Content = classEntry;
        //Address
        var addressLabel = new Label
        {
            Margin = new Thickness(20, 4, 0, 4),
            Text = layout.AddressLabel,
            FontSize = layout.fontSize * .9,
        };

        var addressEntryFrame = new Frame
        {
            HeightRequest = 70
        };

        addressEntry = new Editor
        {
            HeightRequest = 70,
            FontSize = layout.fontSize * .9,
            Placeholder = "Please Enter Address"
        };

        addressEntryFrame.Content = addressEntry;
        //Buttons
        

        deleteButton = new Button
        {
            Margin = new Thickness(0, 15),
            Text = layout.deleteBtnText,
            HeightRequest = 45,
            WidthRequest = 70,
            BackgroundColor = Color.FromArgb("#f3dede"),
            TextColor = Color.FromArgb("#f00"),
            HorizontalOptions = LayoutOptions.Start,
        };
        deleteButton.Clicked += DeleteButton_Clicked;

        
        ////dobAndAge
        //Grid.SetRow(dateOfBirthLabel, 0);
        //Grid.SetColumn(dateOfBirthLabel, 0);

        //Grid.SetRow(dateOfBirthFrame, 1);
        //Grid.SetColumn(dateOfBirthFrame, 0);

        //Grid.SetRow(ageLabel, 0);
        //Grid.SetColumn(ageLabel, 1);

        //Grid.SetRow(ageEntryFrame, 1);
        //Grid.SetColumn(ageEntryFrame, 1);

        //Error Labels
        lblfnameError = new Label
        {
            Margin = new Thickness(20, 3, 0, 0), Text = "", FontSize = layout.fontSize * .7, TextColor = Color.FromRgba("#f00")
        };
        lbllnameError = new Label
        {
            Margin = new Thickness(20, 3, 0, 0), Text = "", FontSize = layout.fontSize * .7, TextColor = Color.FromRgba("#f00")
        };
        lblgenderError = new Label
        {
            Margin = new Thickness(20, 3, 0, 0), Text = "", FontSize = layout.fontSize * .7, TextColor = Color.FromRgba("#f00")
        };

        lblDateOfBirthError = new Label
        {
            Margin = new Thickness(20, 3, 0, 0), Text = "", FontSize = layout.fontSize * .7, TextColor = Color.FromRgba("#f00")
        };
        lblageError = new Label
        {
            Margin = new Thickness(20, 3, 0, 0), Text = "", FontSize = layout.fontSize * .7, TextColor = Color.FromRgba("#f00")
        };

        //DobAndAge Grid
        var dobAgeGrid = new Grid
        {
            ColumnSpacing = 10,
            RowSpacing = 3,
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = 40 },
                new RowDefinition { Height = 40 },
                new RowDefinition { Height = 20 },

            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Star }
            }
        };
        Grid.SetRow(dateOfBirthLabel, 0);
        Grid.SetColumn(dateOfBirthLabel, 0);
        Grid.SetRow(dateOfBirthFrame, 1);
        Grid.SetColumn(dateOfBirthFrame, 0);
        Grid.SetRow(lblDateOfBirthError, 2);
        Grid.SetColumn(lblDateOfBirthError, 0);

        Grid.SetRow(ageLabel, 0);
        Grid.SetColumn(ageLabel, 1);
        Grid.SetRow(ageEntryFrame, 1);
        Grid.SetColumn(ageEntryFrame, 1);
        Grid.SetRow(lblageError, 2);
        Grid.SetColumn(lblageError, 2);

        dobAgeGrid.Children.Add(dateOfBirthLabel);
        dobAgeGrid.Children.Add(dateOfBirthFrame);
        dobAgeGrid.Children.Add(lblDateOfBirthError);

        dobAgeGrid.Children.Add(ageLabel);
        dobAgeGrid.Children.Add(ageEntryFrame);
        dobAgeGrid.Children.Add(lblageError);

        //Main Layout
        Content = new ScrollView
        {
            Content = new StackLayout
            {
                Margin = new Thickness(15),

                Children =
                {
                    firstNameLabel,firstNameEntryFrame,lblfnameError,
                    lastNameLabel,lastNameEntryFrame,lbllnameError,
                    genderLabel,
                    genderPickerFrame,lblgenderError,
                    dobAgeGrid,
                    classLabel,classEntryFrame,
                    addressLabel,addressEntryFrame,
                    deleteButton,
                }

            }
        };

    }

    //Save
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        //All entry and input data should be taken here
        string firstName = firstNameEntry.Text?.Trim();
        string lastName = lastNameEntry.Text?.Trim();
        string gender = genderPicker.SelectedItem as string;
        int genderIndex=genderPicker.SelectedIndex;
        DateTime dateOfBirth = dateOfBirthDatePicker.Date;
        string age = ageEntry.Text;
        string className = classEntry.Text?.Trim();
        string address = addressEntry.Text?.Trim();

        DataLayer dataLayer=new DataLayer();
        dataLayer.setStudentModel(studentModel);

        bool isValid = validateData(firstName, lastName, genderIndex, dateOfBirth, age);
        if(isValid)
        {
            setStudentModelData(firstName, lastName, gender, dateOfBirth, age, className, address);
            if (IsEditMode != "true")
            {
                dataLayer.AddData();
                Shell.Current.GoToAsync("..");
            }
            else
            {
                dataLayer.UpdateData(int.Parse(StudentId));
                Shell.Current.GoToAsync("..");
            }
        }
        
    }


    private void setStudentModelData(string firstName,string lastName,string gender,DateTime dateOfBirth,string age,string className,string address)
    {
        studentModel.FirstName = firstName;
        studentModel.LastName = lastName;
        studentModel.Gender = gender;
        studentModel.DateOfBirth = dateOfBirth;
        studentModel.Age =int.Parse( age);
        studentModel.Class= className;
        studentModel.Address = address;
    }

    private bool validateData(string firstName, string lastName, int genderIndex, DateTime dateOfBirth, string age)
    {
        bool isValid = true;
        string requiredMessage = layout.requiredMessage;
        if (string.IsNullOrEmpty(firstName))
        {
            lblfnameError.Text = requiredMessage;
            isValid = false;
        }
        else if (firstName.Length > 15 || firstName.Length < 3)
        {
            lblfnameError.Text = layout.firstNameSpError;
            isValid = false;
        }
        else
        {
            lblfnameError.Text = "";
        }

        if (string.IsNullOrEmpty(lastName))
        {
            lbllnameError.Text = requiredMessage;
            isValid = false;
        }
        else if (lastName.Length > 18 || lastName.Length < 2)
        {
            lbllnameError.Text = layout.lastNameSpError;
            isValid = false;
        }
        else
        {
            lbllnameError.Text = "";
        }

        if (genderIndex == -1)
        {
            lblgenderError.Text = requiredMessage;
            isValid = false;
        }
        else
        {
            lblgenderError.Text = "";
        }

        if (dateOfBirth == DateTime.Now.Date)
        {
            lblDateOfBirthError.Text = requiredMessage;
            isValid = false;
        }
        else
        {
            lblDateOfBirthError.Text = "";
        }

        if (string.IsNullOrEmpty(age))//int.Parse(age) == 0
        {
            lblageError.Text = requiredMessage;
            isValid = false;
        }
        else if (int.Parse(age) > 99 || int.Parse(age) < 5)
        {
            lblageError.Text = layout.ageSpError;
            isValid = false;
        }
        else
        {
            lblageError.Text = "";
        }
        return isValid;
    }

    //Delete
    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this student record?", "Yes", "No");

        if (answer)
        {
            DataLayer dataLayer = new DataLayer();
            dataLayer.setStudentModel(studentModel);

            dataLayer.DeleteData(int.Parse(StudentId));
            await Shell.Current.GoToAsync("..");
        }
        
    }

    //Calculate age from DateOfBirth

    private void DateOfBirthDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        ageEntry.Text= (DateTime.Now.Year-e.NewDate.Year).ToString();
        if (ageEntry.Text == "0")
        {
            ageEntry.Text = "";
        }
    }
    //Claculate Date from Age
    private void AgeEntry_TextChanged(object sender, TextChangedEventArgs e)
    {

        if (int.TryParse(ageEntry.Text, out int age))
        {
            
            // Update the DateOfBirthDatePicker with the calculated date of birth
            dateOfBirthDatePicker.Date = DateTime.Now.AddYears(-age);
        }
        else
        {
            dateOfBirthDatePicker.Date = DateTime.Now;
            ageEntry.Text = "";
        }
    }

    //Inputs
    private void LastNameEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        preventNumerics(e.NewTextValue, out string textonly);
        lastNameEntry.Text = textonly;
    }
    private void FirstNameEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        preventNumerics(e.NewTextValue,out string textonly);
        firstNameEntry.Text = textonly;
    }
    private void preventNumerics(string text ,out string textOnly)
    {
        textOnly = Regex.Replace(text, "[^a-zA-Z]", "");
    }

}