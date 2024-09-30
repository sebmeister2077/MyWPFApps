using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement;

public class MainViewModel : INotifyPropertyChanged
{
    private int _totalUsers;

    public int TotalUsers
    {
        get { return _totalUsers; }
        set
        {
            _totalUsers = value;
            OnPropertyChanged(nameof(TotalUsers));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public MainViewModel()
    {
        TotalUsers = 0;
    }
}
