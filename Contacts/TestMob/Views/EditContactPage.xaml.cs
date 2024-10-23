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
                ContactCtrl.Name = contact.Name;
                ContactCtrl.Address = contact.Address;
                ContactCtrl.Email = contact.Email;
                ContactCtrl.Phone = contact.Phone;
            }
        }
    }

    private void BtnUpdate_OnClicked(object? sender, EventArgs e)
    {
        contact.Name = ContactCtrl.Name;
        contact.Address = ContactCtrl.Address;
        contact.Phone = ContactCtrl.Phone;
        contact.Email = ContactCtrl.Email;

        ContactRepository.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");
    }

    private void ContactCtrl_OnOnError(object? sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}