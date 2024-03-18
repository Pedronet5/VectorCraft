namespace VectorCalculatorApp.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using VectorCraft;

    public class VectorViewModel : INotifyPropertyChanged
    {
        private double _vector1X;
        public double Vector1X
        {
            get => _vector1X;
            set
            {
                if (_vector1X != value)
                {
                    _vector1X = value;
                }
            }
        }

        private double _vector1Y;
        public double Vector1Y
        {
            get => _vector1Y;
            set
            {
                if (_vector1Y != value)
                {
                    _vector1Y = value;
                }
            }
        }

        private double _vector1Z;
        public double Vector1Z
        {
            get => _vector1Z;
            set
            {
                if (_vector1Z != value)
                {
                    _vector1Z = value;
                }
            }
        }

        private double _vector2X;
        public double Vector2X
        {
            get => _vector2X;
            set
            {
                if (_vector2X != value)
                {
                    _vector2X = value;
                }
            }
        }

        private double _vector2Y;
        public double Vector2Y
        {
            get => _vector2Y;
            set
            {
                if (_vector2Y != value)
                {
                    _vector2Y = value;
                }
            }
        }

        private double _vector2Z;
        public double Vector2Z
        {
            get => _vector2Z;
            set
            {
                if (_vector2Z != value)
                {
                    _vector2Z = value;
                }
            }
        }

        private Vector3D? _crossProductResult;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Vector3D CrossProductResult
        {
            get => _crossProductResult;
            set
            {
                _crossProductResult = value; 
                OnPropertyChanged();
            }
        }

        public void ComputeCrossProduct()
        {
            // Calculate the cross product
            var vector1 = new Vector3D(Vector1X, Vector1Y, Vector1Z);
            var vector2 = new Vector3D(Vector2X, Vector2Y, Vector2Z);

            CrossProductResult = vector1.CrossProduct(vector2);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
