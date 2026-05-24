const apiUrl = "http://localhost:5244/api/contacts";

async function loadContacts() {
  const response = await fetch(apiUrl);
  const contacts = await response.json();
  const tbody = document.getElementById("contactList");
  tbody.innerHTML = "";

  contacts.forEach((contact) => {
    const row = document.createElement("tr");
    row.innerHTML = `
            <td>${contact.name}</td>
            <td>${contact.phone}</td>
            <td>${contact.email}</td>
            <td>
                <button class="edit-btn" onclick="editContact('${contact.id}', '${contact.name}', '${contact.phone}', '${contact.email}')">Edit</button>
                <button class="delete-btn" onclick="deleteContact('${contact.id}')">Delete</button>
            </td>
        `;
    tbody.appendChild(row);
  });
}


async function saveContact() {
  const id = document.getElementById("contactId").value;
  const name = document.getElementById("name").value.trim();
  const phone = document.getElementById("phone").value.trim();
  const email = document.getElementById("email").value.trim();

  if (!name || !phone || !email) {
    alert("fields should not be empty!");
    return;
  }

  const contact = { name, phone, email };
  if (id) {
    await fetch(`${apiUrl}/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ ...contact, id }),
    });
  } else {
    await fetch(apiUrl, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(contact),
    });
  }

  clearForm();
  loadContacts();
}

function editContact(id, name, phone, email) {
  document.getElementById("contactId").value = id;
  document.getElementById("name").value = name;
  document.getElementById("phone").value = phone;
  document.getElementById("email").value = email;
  document.getElementById("form-title").textContent = "Edit Contact";
}

async function deleteContact(id) {
  if (confirm("Delete this contact?")) {
    await fetch(`${apiUrl}/${id}`, { method: "DELETE" });
    loadContacts();
  }
}

function clearForm() {
  document.getElementById("contactId").value = "";
  document.getElementById("name").value = "";
  document.getElementById("phone").value = "";
  document.getElementById("email").value = "";
  document.getElementById("form-title").textContent = "Add Contact";
}

loadContacts();
