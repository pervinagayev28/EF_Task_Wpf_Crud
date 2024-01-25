﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Whatsapp.Services
{
    public class ServiceINotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? PropertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }
}