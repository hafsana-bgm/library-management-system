
$(document).ready(function () {
	// Debounce function
	function debounce(func, delay) {
		let timeoutId;
		return function (...args) {
			clearTimeout(timeoutId);
			timeoutId = setTimeout(() => func.apply(this, args), delay);
		};
	}

	// Function to populate selected suggestion
	function populateSuggestion(item) {
		$('#MemberId').val(item.id || '0');
		$('#MemberName').val(item.name || '');
		$('#MemberPhone').val(item.phone || '');
		$('#MemberAddress').val(item.address || '');
		$('#suggestions').hide();
	}

	// Fetch phone suggestions
	const fetchPhoneSuggestions = debounce(function (phoneNumber) {
		if (phoneNumber.length < 3) {
			$('#suggestions').hide();
			return;
		}

		$.ajax({
			url: '/BookSell/Phone',
			type: 'GET',
			data: { phone: phoneNumber },
			success: function (data) {
				const suggestionsDiv = $('#suggestions');
				suggestionsDiv.empty().hide();

				if (data.success && data.search && data.search.length) {
					data.search.forEach(function (item) {
						const suggestionItem = $(`
									<div class="suggestion-item"
										 style="padding: 5px; cursor: pointer;"
										 data-id="${item.memberId}"
										 data-name="${item.memberName}"
										 data-phone="${item.memberPhone}"
										 data-address="${item.memberAddress}">
										 ${item.memberName} - ${item.memberPhone}
									</div>
								`);

						suggestionItem.on('click', function () {
							populateSuggestion({
								id: $(this).data('id'),
								name: $(this).data('name'),
								phone: $(this).data('phone'),
								address: $(this).data('address')
							});
						});

						suggestionsDiv.append(suggestionItem);
					});
					suggestionsDiv.show();
				} else {
					suggestionsDiv.append(`<div style="padding: 5px;">No suggestions found</div>`);
					suggestionsDiv.show();
				}
			},
			error: function () {
				console.error('Error fetching phone suggestions.');
				$('#suggestions').hide();
			}
		});
	}, 300); // Debounce delay

	// Attach input event
	$('#MemberPhone').on('input', function () {
		const phoneNumber = $(this).val();
		$('#MemberId').val('0');
		fetchPhoneSuggestions(phoneNumber);
	});

	// Hide suggestions on outside click
	$(document).on('click', function (e) {
		if (!$(e.target).closest('#MemberPhone, #suggestions').length) {
			$('#suggestions').hide();
		}
	});
});

function addRow() {
	//get input values
	const description = document.getElementById("Description").value;//user jei input dibe seta get korara jonno document.getElementById() dey.
	const quantity = parseFloat(document.getElementById("Quantity").value);
	const price = parseFloat(document.getElementById("Price").value);
	const discount = parseFloat(document.getElementById("Discount").value) || 0; // || 0 mane holo user inpt na dile ekta 0 return korbe.

	//Calculate total after discount
	const total = quantity * price * (1 - discount / 100); //const er man poriborrton kora jay na, let er man priborton kora jay.

	//Create new row HTML
	const table = document.querySelector("#ProductTable tbody");
	const row = document.createElement("tr");

	row.innerHTML = `
			<td>${description}</td>
			<td>${quantity}</td>
			<td>${price}</td>
			<td>${discount}</td>
			<td>${total.toFixed(2)}</td>
			<td><button class="btn btn-danger btn-sm" onclick="deleteRow(this)">Delete</button></td>
		`;
	// #ProductTable tbody = টেবিলের বডি, যেটার ভিতরে নতুন সারি (row) বসাতে চাও। createElement("tr")=একটি নতুন টেবিলের সারি তৈরি করছো। appendChild(row) = ঐ tbody-র একদম শেষে সেই row বসিয়ে দিচ্ছো।
	//ধরো তোমার একটা খালি ব্যাগ আছে (মানে table body),তুমি একটা কলা (row) তৈরি করছো,আর appendChild() মানে তুমি ব্যাগে সেই কলাটা রেখে দিচ্ছো।

	table.appendChild(row);

	document.getElementById("Description").value = "";
	document.getElementById("Quantity").value = 1;
	document.getElementById("Price").value = "";
	document.getElementById("Discount").value = "";
	document.getElementById("Total").value = "0";

}

//Delete Row
// button element er kacher row khuje ber korar jonno closest use kore.
//.remove() mane row khuje delete kore deo.
function deleteRow(button) {
	button.closest("tr").remove();
}


function calculate(input) {
	let row = input.closest('.row'); // সঠিকভাবে row খুঁজে বের করা
	let quantityInput = row.querySelector('[id="Quantity"]');
	let priceInput = row.querySelector('[id="Price"]');
	let discountInput = row.querySelector('[id="Discount"]');
	let totalInput = row.querySelector('[id="Total"]');

	let quantity = parseFloat(quantityInput.value) || 0; //user jokhon data na dibe tokhon false return korara jonno ||0 dewa hoy.
	let price = parseFloat(priceInput.value) || 0;
	let discount = parseFloat(discountInput.value) || 0;

	let total = quantity * price;
	let discountAmount = total * (discount / 100);
	let finalAmount = total - discountAmount;

	totalInput.value = finalAmount.toFixed(2); // দুই ঘর দশমিক
}


$('#SaveButton').click(function () {

	var InvoiceData = {
		InvoiceID: parseInt($('#InvoiceID').val()),
		PrinterName: $('#PrinterName').val(),
		Date: $('#Date').val(),
		Subtotal: parseFloat($('#Subtotal').val()),
		TotalDiscount: parseFloat($('#TotalDiscount').val()),
		Discount: parseFloat($('#Discount').val())
	};

	var Invoiceproduct = {
		Id: parseInt($('#InvoiceProductId').val()),
		Description: $('#Description').val(),
		Quantity: parseInt($('#Quantity').val()),
		Price: parseFloat($('#Price').val()),
		Discount: parseFloat($('#Discount').val()),
		Total: parseFloat($('#Total').val())
	};

	var MemberDetails = {
		MemberId: parseInt($('#MemberId').val()),
		MemberName: $('#MemberName').val(),
		MemberPhone: $('#MemberPhone').val(),
		MemberAddress: $('#MemberAddress').val()
	};
	debugger;
	var product = {
		Invoice: InvoiceData,
		Invoiceproduct: Invoiceproduct,
		Membe= MemberDetails
	};

	$.ajax({
		url: '/BookSell/OrderList',
		type: 'POST',
		contentType: 'application/json',
		data: JSON.stringify(product),
		success: function (response) {
			alert(response.success ? 'Success!' : 'Failed: ' + response.message);
		},
		error: function () {
			alert('Server error occurred!');
		}
	});
});
