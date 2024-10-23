using Microsoft.Maui.ApplicationModel.Communication;
using TestMob.Models;
using Contact = TestMob.Models.Contact;

namespace TestMob.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void BtnCancel_OnClicked(object? sender, EventArgs e)
    {
        // Shell.Current.GoToAsync("..");
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void ContactCtrl_OnOnSave(object? sender, EventArgs e)
    {
        ContactRepository.AddContact(new Contact
        {
            Name = ContactCtrl.Name,
            Address = ContactCtrl.Address,
            Phone = ContactCtrl.Phone,
            Email = ContactCtrl.Email
        });

        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void ContactCtrl_OnOnError(object? sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}