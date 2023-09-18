const urlParams = new URLSearchParams(window.location.search);
const h1Text = urlParams.get('h1Text');
const currentDate = new Date();
const StudentHeader = document.querySelector('h1');
let EditMode = false;
//Selecting Inputs
const FirstName = document.getElementById('firstName');
const LastName = document.getElementById('lastName');
const Gender = document.getElementById('gender');
const DateOfBirth = document.getElementById('dateOfBirth');
const Age = document.getElementById('age');
const _Class = document.getElementById('class');
const Address = document.getElementById('address');


const StudentData = {
    firstName: '',
    lastName: '',
    genderIndex: 2,
    dateOfBirth: '',
    age: '',
    class: '',
    address: '',
    gender: ''
};

//Setting Data
function setStudentData() {
    
    StudentData.firstName = FirstName.value.trim();
    StudentData.lastName = LastName.value.trim();
    StudentData.genderIndex = Gender.value;
    StudentData.dateOfBirth = DateOfBirth.value;
    StudentData.age = Age.value;
    StudentData.class = _Class.value.trim();
    StudentData.address = Address.value.trim();

    function genderValue() {
        if (StudentData.genderIndex !== 2) {
            if (StudentData.genderIndex === 0) {
                return "Male";
            } else {
                return "Female";
            }
        } else {
            return "";
        }
    };
    StudentData['gender'] = genderValue();
    var gen = StudentData.gender;
    return validateFields(StudentData.firstName, StudentData.lastName, StudentData.genderIndex, StudentData.dateOfBirth, StudentData.age);
}




//Data Validation

function validateFields(firstName, lastName, genderIndex, dateOfBirth, age) {
    let isValid = true;
    const requiredMessage = "This Field is required";

    const errFirstName = document.querySelector('.fname-err');
    const errLastName = document.querySelector('.lname-err');
    const errGender = document.querySelector('.gender-err');
    const errDateOfBirth = document.querySelector('.dob-err');
    const errAge = document.querySelector('.age-err');

    if (!firstName) {
        errFirstName.textContent = requiredMessage;
        isValid = false;
    } else if (firstName.length > 15 || firstName.length < 3) {
        errFirstName.textContent = "The First Name field should have min 3 characters and max 15 characters";
        isValid = false;
    } else {
        errFirstName.textContent = "";
    }

    if (!lastName) {
        errLastName.textContent = requiredMessage;
        isValid = false;
    } else if (lastName.length > 18 || lastName.length < 2) {
        errLastName.textContent = "The last Name field should have min 2 characters and max 18 characters";
        isValid = false;
    } else {
        errLastName.textContent = "";
    }

    if (genderIndex === "2" || genderIndex==="") {
        errGender.textContent = requiredMessage;
        isValid = false;
    } else {
        errGender.textContent = "";
    }

    if (dateOfBirth === "") {
        errDateOfBirth.textContent = requiredMessage;
        isValid = false;
    } else {
        errDateOfBirth.textContent = "";
    }

    if (age === "") {
        errAge.textContent = requiredMessage;
        isValid = false;
    } else if (parseInt(age) > 99 || parseInt( age) < 5) {
        errAge.textContent = "Age value should be\n between 5 and 99";
        isValid = false;
    } else {
        errAge.textContent = "";
    }

    return isValid;
}


//------------Api Calls Section----------
//Save Button Click
$(document).ready(function () {
    $('#saveBtn').on('click', (e) => {
        e.preventDefault();
        const DataApproved=setStudentData();
        if (DataApproved) {
            if (!EditMode) {
                
                const jsonData = JSON.stringify(StudentData);
                $.ajax({
                    url: '/home/Add',
                    method: 'POST',
                    contentType: 'application/json',
                    data: jsonData,
                    success: function (data) {
                        if (data === "Data received and processed successfully") {
                            window.location.href = '/'; 
                        }
                    },
                    error: function (error) {
                        console.error('AJAX error:', error);
                    }
                });
            } else {
                StudentData['studentId'] = urlParams.get('studentId');
                const jsonData = JSON.stringify(StudentData);

                $.ajax({
                    url: '/home/Edit',
                    method: 'POST',
                    contentType: 'application/json', 
                    data: jsonData,
                    success: function (data) {
                        if (data === "Data received and processed successfully") {
                            window.location.href = '/';
                        }
                    },
                    error: function (error) {
                        console.error('AJAX error:', error);
                    }
                });

            }
            
        }
        
    });
});

//Delete Button Click
$('#deleteBtn').on('click', (e) => {
    e.preventDefault();
    const confirmation = window.confirm("Are you sure you want to delete this student records?");
    if (confirmation) {
        let studentId = parseInt(urlParams.get('studentId'));
        $.ajax({
            url: '/home/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(studentId),
            success: function (data) {
                if (data === "Data received and processed successfully") {
                    window.location.href = '/';
                }
            },
            error: function (error) {
                console.error('AJAX error:', error);
            }
        });
    } else {
        e.preventDefault();
    }
});

$(document).ready(function () {
if (urlParams) {
    if (urlParams.get('studentId')) {
        var id = urlParams.get('studentId'); 
        $.get("/home/selectedStudent?id=" + id, function (data) {
            console.log(data);
            FirstName.value = data[1];
            LastName.value = data[2];
            Gender.value = data[8];
            const dobDate = new Date(data[7]);
            dobDate.setMinutes(dobDate.getMinutes() + 330);
            const dobISOString = dobDate.toISOString().split('T')[0];
            DateOfBirth.value = dobISOString;
            Age.value = data[4].toString().split(' ')[0].trim();
            _Class.value = data[5];
            Address.value = data[6];
            EditMode = true;
            StudentHeader.textContent = "Edit Student";
            $('#deleteBtn').toggleClass('hide');
        });
    }
}
});



//------------Api Calls Section End----------


//Set Age from dateOFBIrth
DateOfBirth.addEventListener('input', ()=>{
    const selectedDate = new Date(DateOfBirth.value);
    const currentDate = new Date();
    const ageInYears = currentDate.getFullYear() - selectedDate.getFullYear();
    Age.value = ageInYears.toString();
    if (Age.value === '0') {
        Age.value = '';
    }
});

//set DateOfBirth from Age
Age.addEventListener('keyup', () => {
    if (Age.value === "" || Age.value == "0") {
        DateOfBirth.value = currentDate.toISOString().split('T')[0];
    } else {
        let birthYear = currentDate.getFullYear() - parseInt(Age.value);
        //const newDate = new Date(currentYear, currentMonth, currentDay);
        let dob = new Date(birthYear, 0, 2);
        DateOfBirth.value = dob.toISOString().split('T')[0];
    }
})

//Handle key press events
// Function to handle key presses and allow only letters and spaces
function handleKeyPress(event) {
    const charCode = event.which || event.keyCode;
    if (
        !((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || charCode === 32 || charCode === 8)
    ) {
        event.preventDefault();
    }
}
// Function to handle key presses and allow only digits
function handleKeyPressDigits(event) {
    const charCode = event.which || event.keyCode;
    if (!(charCode >= 48 && charCode <= 57) && charCode !== 8) {
        event.preventDefault();
    }
}

FirstName.addEventListener('keypress', handleKeyPress);
LastName.addEventListener('keypress', handleKeyPress);
Age.addEventListener('keypress', handleKeyPressDigits);
DateOfBirth.addEventListener('keydown', function (e) {
    e.preventDefault();
});

