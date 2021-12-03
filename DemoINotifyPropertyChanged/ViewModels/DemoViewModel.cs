using System.ComponentModel;

namespace DemoINotifyPropertyChanged.ViewModels;

internal class DemoViewModel : INotifyPropertyChanged
{
    public DemoViewModel()
    {
        //Populate with default values
        firstName = "Bob"; lastName = "Smith";
        //Update the controls
        OPC();
    }

    private string firstName, lastName;


    public string FirstName{
        get => firstName;
        set { firstName = value; OPC(); }}

    public string LastName {
        get => lastName;
        set { lastName = value; OPC(); }}

    //? prevents getting null warnings, but isn't necessary
    public string? FullName { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OPC()
    {
        FullName = $"{FirstName} {LastName}";

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
