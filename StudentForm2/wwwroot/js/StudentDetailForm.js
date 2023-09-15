//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.

// For Sorting
$(document).ready(function () {
    const $table = $('#table');
    const $tableBody = $('#tableBody');

    // Bind click event to all th elements
    $table.find('th').on('click', function () {
        const $header = $(this);
        const columnIndex = $header.index() + 1; // 1-based index

        const rows = $tableBody.find('tr');

        rows.sort(function (row1, row2) {
            const cell1 = $(row1).find('td').eq(columnIndex - 1).text();
            const cell2 = $(row2).find('td').eq(columnIndex - 1).text();

            if (columnIndex === 4) {
                const age1 = parseInt(cell1.substr(0, 2));
                const age2 = parseInt(cell2.substr(0, 2));
                return age1 - age2; // Compare as integers
            } else {
                return cell1.localeCompare(cell2);
            }
        });

        // Remove existing rows
        $tableBody.empty();

        // Append sorted rows back to the table
        rows.each(function () {
            $tableBody.append($(this));
        });
    });
    $tableBody.on('click', 'tr', function () {
        $tableBody.find('tr').removeClass('selectedRow');
        $(this).toggleClass('selectedRow');
    });

    // Initialize the first row as selected
    $tableBody.find('tr').eq(0).addClass('selectedRow');
});

$(document).ready(function () {
    const $searchBox = $('#search');
    const $table = $('#table');
    $searchBox.on('input', function () {
        const searchTerm = $searchBox.val().trim().toLowerCase();
        const $rows = $table.find('tbody tr');
        $rows.each(function () {
            const $row = $(this);
            const cell1 = $row.find('td:eq(0)').text().trim().toLowerCase();
            const cell2 = $row.find('td:eq(1)').text().trim().toLowerCase();
            const cell4 = $row.find('td:eq(3)').text().trim().toLowerCase();

            const ageMatch = cell4.substring(0, 2).trim();
            const matched = cell1.includes(searchTerm) ||
                cell2.includes(searchTerm) ||
                ageMatch.includes(searchTerm);

            $row.toggle(matched);
        });
    });
});
