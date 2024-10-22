using TestMob.Models;
using Contact = TestMob.Models.Contact;

namespace TestMob.Views;

[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void BtnCancel_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(int.Parse(value));
            if (contact != null)
            {
                entryName.Text = contact.Name;
                entryAddress.Text = contact.Address;
                entryEmail.Text = contact.Email;
                entryPhone.Text = contact.Phone;
            }
        }
    }

    private void BtnUpdate_OnClicked(object? sender, EventArgs e)
    {
        contact.Name = entryName.Text;
        contact.Address = entryAddress.Text;
        contact.Phone = entryPhone.Text;
        contact.Email = entryEmail.Text;

        ContactRepository.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");
    }
}