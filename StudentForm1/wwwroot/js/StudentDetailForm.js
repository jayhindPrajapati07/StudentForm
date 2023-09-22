// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const tableBody = document.getElementById("tableBody");
let data;

function createRow(studentData, data) {
    const newRow = document.createElement("tr");
    newRow.setAttribute("id", studentData[0]);

    const cellFirstName = document.createElement("td");
    cellFirstName.textContent = studentData[1];
    newRow.appendChild(cellFirstName);

    const cellLastName = document.createElement("td");
    cellLastName.textContent = studentData[2];
    newRow.appendChild(cellLastName);

    const cellGender = document.createElement("td");
    cellGender.textContent = studentData[3];
    newRow.appendChild(cellGender);

    const cellAge = document.createElement("td");
    cellAge.textContent = studentData[4];
    newRow.appendChild(cellAge);

    const cellClass = document.createElement("td");
    cellClass.textContent = studentData[5];
    newRow.appendChild(cellClass);

    newRow.addEventListener("click", () => {
        newRow.classList.toggle('selectedRow');
    });

    newRow.addEventListener('dblclick', () => {
        const rowId = newRow.getAttribute('id');

        if (rowId) {
            
            const redirectUrl = `/home/AddEditForm?studentId=${rowId}`;
            window.location.href = redirectUrl;
        }
    });

    return newRow;
}

// For Searching
function displayRows(searchText) {
    const rows = tableBody.querySelectorAll('tr');
    searchText = searchText.toLowerCase();

    rows.forEach(row => {
        const studentData = data.find(item => item[0] === row.getAttribute('id'));
        if (!studentData) {
            row.style.display = 'none';
        } else {
            const searchString = [studentData[1], studentData[2], studentData[4].toString().split(" ")[0]].join(" ").toLowerCase();
            if (searchString.includes(searchText)) {
                row.style.display = '';
            } else {
                row.style.display = 'none';
            }
        }
    });
}


$(document).ready(function () {
    $.get("/home/GetStudents", function (responseData) {
        data = responseData;
        console.log(data);
        for (let i = 0; i < data.length; i++) {
            const newRow = createRow(data[i], data);
            tableBody.appendChild(newRow);
        }

        $('#tableBody tr')[0].classList = 'selectedRow';
        $('#tableBody tr').click(function () {
            $('#tableBody tr').removeClass('selectedRow');

            $(this).toggleClass('selectedRow');
        });

        // Event listener for keypress in the search input
        $('#search').on('input', function () {
            const searchText = $(this).val();
            displayRows(searchText);
        });
    });
    
});


//For Sorting 
const fnameHeader = document.getElementById("fnameHeader");
const lnameHeader = document.getElementById("lnameHeader");
const genderHeader = document.getElementById("genderHeader");
const ageHeader = document.getElementById("ageHeader");
const classHeader = document.getElementById("classHeader");

let ascending = true; // Flag to track sorting direction

fnameHeader.addEventListener("click", () => {
    sortTable(1); // Sort based on the FirstName (index 1) column
});

lnameHeader.addEventListener("click", () => {
    sortTable(2);
});

genderHeader.addEventListener("click", () => {
    sortTable(3);
});

ageHeader.addEventListener("click", () => {
    sortTable(4);
});

classHeader.addEventListener("click", () => {
    sortTable(5);
});

function sortTable(columnIndex) {
    const rows = Array.from(tableBody.querySelectorAll("tr"));

    rows.sort((row1, row2) => {
        const data1 = data.find(item => item[0] === row1.getAttribute('id'));
        const data2 = data.find(item => item[0] === row2.getAttribute('id'));

        if (columnIndex === 4) {
            const age1 = parseInt(data1[4].substr(0, 2));
            const age2 = parseInt(data2[4].substr(0, 2));
            const comparison = age1 - age2; // Compare as integers
            return ascending ? comparison : -comparison; // Toggle sorting direction
        } else {
            // For other columns, use localeCompare to perform a string comparison
            const cell1 = data1[columnIndex];
            const cell2 = data2[columnIndex];
            const comparison = cell1.localeCompare(cell2);
            return ascending ? comparison : -comparison; // Toggle sorting direction
        }
    });

    // Toggle sorting direction for the next click
    ascending = !ascending;

    // Remove existing rows
    tableBody.innerHTML = '';

    // Append sorted rows back to the table
    rows.forEach(row => {
        tableBody.appendChild(row);
    });
}
