// Update the customer table whenever the customer page is displayed
updateCustomerTable();

// Posts the customer data from the form to the controller
function addCustomer() {
	var customer = {
		Name: $("#addCustomerModal #Name").val(),
		Address: $("#addCustomerModal #Address").val()
	};

	$.ajax({
		type: "POST",
		url: "/Customers/AddCustomer",
		data: customer,
		error: function (xhr, statusText, error) {
			alert("Error: " + statusText + " " + error);
		},
		success: function (data) {
			$("#addCustomerModal #Name").val('');
			$("#addCustomerModal #Address").val('');

			updateCustomerTable();
		}
	})


}

// Saves the edited customer to the model
function editCustomer() {
	var customer = {
		ID: $("#CustomerId").val(),
		Name: $("#editCustomerModal #CustomerName").val(),
		Address: $("#editCustomerModal #Address").val()
	};

	$.post("/Customers/EditCustomer", customer, function (data, status) {
		updateCustomerTable();
	});
}

// Deletes the selected customer
function deleteCustomer() {
	var data = {
		CustomerId: $("#CustomerId").val()
	}

	$.post("/Customers/DeleteCustomer", data, function (data, status) {
		updateCustomerTable();
	});
}

// Opens the edit customer modal. Fills out the information of the form
function openEditCustomerModal(customer) {
	$("#editCustomerModal").modal("toggle");
	$("#CustomerId").val(customer.CustomerId);
	$("#editCustomerModal #CustomerName").val(customer.CustomerName);
	$("#editCustomerModal #Address").val(customer.Address);
}

// Opens the delete customer modal. Fills out the information of the customer you want to delete
function openDeleteCustomerModal(customer) {
	$("#deleteCustomerModal").modal("toggle");
	$("#CustomerId").val(customer.CustomerId);
	$("#deleteCustomerModal #CustomerName").text(customer.CustomerName);
	$("#deleteCustomerModal #Address").text(customer.Address);
}

// Populates the customers table
function updateCustomerTable() {
	$.ajax({
		type: "GET",
		url: "/Customers/GetCustomers",
		contentType: "application/json; charset=utf-8",
		error: function (xhr, statusText, error) {
			alert("Error: " + statusText + " " + error);
		},
		success: function (data) {
			$("#customerTable tr td").remove();

			for (var i = 0; i < data.length; i++) {
				updateCustomerRow(i, data[i]);
			}
		}
	})
}

// Updates one row of the customer table
function updateCustomerRow(index, customer) {
	$("#customerTable").append("<tr><td>" + customer.CustomerName + "</td>" +
		"<td>" + customer.Address + "</td>" +
		"<td><button type='button' class='btn btn-warning' onclick='openEditCustomerModal(" + JSON.stringify(customer) + ")'><span class= 'glyphicon glyphicon-edit'></span> Edit</button></td>" +
		"<td><button type='button' class='btn btn-danger' onclick='openDeleteCustomerModal(" + JSON.stringify(customer) + ")'><span class='glyphicon glyphicon-trash'></span> Delete</button></td></tr>");
}