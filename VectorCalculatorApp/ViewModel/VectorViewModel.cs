namespace VectorCalculatorApp.ViewModel
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using Prism.Commands;
    using VectorCraft;

    public class VectorViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private string? _errorMessage;
        public DelegateCommand ComputeCrossProductCommand { get; }

        public VectorViewModel()
        {
            ComputeCrossProductCommand = new DelegateCommand(ComputeCrossProduct, CanComputeCrossProduct);
        }

        #region Properties

        private string? _vector1X;

        public string Vector1X
        {
            get => _vector1X;
            set
            {
                if (_vector1X != value)
                {
                    _vector1X = value;
                    OnPropertyChanged(nameof(Vector1X));
                    ValidateProperty(value, nameof(Vector1X));
                }
            }
        }

        private string? _vector1Y;

        public string Vector1Y
        {
            get => _vector1Y;
            set
            {
                if (_vector1Y != value)
                {
                    _vector1Y = value;
                    OnPropertyChanged(nameof(Vector1Y));
                    ValidateProperty(value, nameof(Vector1Y));
                }
            }
        }

        private string? _vector1Z;

        public string Vector1Z
        {
            get => _vector1Z;
            set
            {
                if (_vector1Z != value)
                {
                    _vector1Z = value;
                    OnPropertyChanged(nameof(Vector1Z));
                    ValidateProperty(value, nameof(Vector1Z));
                }
            }
        }

        private string? _vector2X;

        public string Vector2X
        {
            get => _vector2X;
            set
            {
                if (_vector2X != value)
                {
                    _vector2X = value;
                    OnPropertyChanged(nameof(Vector2X));
                    ValidateProperty(value, nameof(Vector2X));
                }
            }
        }

        private string? _vector2Y;

        public string Vector2Y
        {
            get => _vector2Y;
            set
            {
                if (_vector2Y != value)
                {
                    _vector2Y = value;
                    OnPropertyChanged(nameof(Vector2Y));
                    ValidateProperty(value, nameof(Vector2Y));
                }
            }
        }

        private string? _vector2Z;

        public string Vector2Z
        {
            get => _vector2Z;
            set
            {
                if (_vector2Z != value)
                {
                    _vector2Z = value;
                    OnPropertyChanged(nameof(Vector2Z));
                    ValidateProperty(value, nameof(Vector2Z));
                }
            }
        }

        private Vector3D? _crossProductResult;

        public Vector3D CrossProductResult
        {
            get => _crossProductResult;
            set
            {
                if (_crossProductResult != value)
                {
                    _crossProductResult = value;
                    OnPropertyChanged(nameof(CrossProductResult));
                }
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        #endregion Properties

        public void ComputeCrossProduct()
        {
            // Validate input before calculations
            if (!ValidateInput())
                return;

            // Calculate the cross product
            var vector1 = new Vector3D(double.Parse(Vector1X), double.Parse(Vector1Y), double.Parse(Vector1Z));
            var vector2 = new Vector3D(double.Parse(Vector2X), double.Parse(Vector2Y), double.Parse(Vector2Z));

            CrossProductResult = vector1.CrossProduct(vector2);
        }

        private bool ValidateInput()
        {
            // Validate each input property individually
            if (!double.TryParse(Vector1X, out _))
            {
                // Set an error message
                ErrorMessage = "Invalid input for Vector 1X. Enter a valid number.";
                return false;
            }

            if (!double.TryParse(Vector1Y, out _))
            {
                ErrorMessage = "Invalid input for Vector 1Y. Enter a valid number.";
                return false;
            }

            if (!double.TryParse(Vector1Z, out _))
            {
                ErrorMessage = "Invalid input for Vector 1Z. Enter a valid number.";
                return false;
            }

            if (!double.TryParse(Vector2X, out _))
            {
                ErrorMessage = "Invalid input for Vector 2X. Enter a valid number.";
                return false;
            }

            if (!double.TryParse(Vector2Y, out _))
            {
                ErrorMessage = "Invalid input for Vector 2Y. Enter a valid number.";
                return false;
            }

            if (!double.TryParse(Vector2Z, out _))
            {
                ErrorMessage = "Invalid input for Vector 2Z. Enter a valid number.";
                return false;
            }

            // If all validations pass, clean message error and return true
            ErrorMessage = "";

            return true;
        }

        private bool CanComputeCrossProduct()
        {
            return true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            // Trigger PropertyChanged event for the specified property
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ValidateProperty(object value, string propertyName)
        {
            // Trigger ErrorsChanged event for the specified property
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        // Skipping this method is mandatory.
        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName == nameof(Vector1X))
            {
                if (!double.TryParse(Vector1X, out _))
                    yield return "Invalid input. Enter a valid number.";
            }
        }

        public bool HasErrors => false;
    }
}
