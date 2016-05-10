namespace WixMVVMBurnUI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private Dictionary<string, object> propertyValueStorage;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ViewModelBase()
        {
            this.propertyValueStorage = new Dictionary<string, object>();
        }

        protected void SetValue<T>(Expression<Func<T>> property, T value)
        {
            if (property == null)
            {
                throw new ArgumentException("Invalid lambda expression", "Lambda expression return value can't be null");
            }
            string propertyName = this.GetPropertyName(property);
            T value2 = this.GetValue<T>(propertyName);
            if (!object.Equals(value2, value))
            {
                this.propertyValueStorage[propertyName] = value;
                this.OnPropertyChanged(propertyName);
            }
        }

        protected T GetValue<T>(Expression<Func<T>> property)
        {
            if (property == null)
            {
                throw new ArgumentException("Invalid lambda expression", "Lambda expression return value can't be null");
            }
            string propertyName = this.GetPropertyName(property);
            return this.GetValue<T>(propertyName);
        }

        private T GetValue<T>(string propertyName)
        {
            object obj;
            if (this.propertyValueStorage.TryGetValue(propertyName, out obj))
            {
                return (T)((object)obj);
            }
            return default(T);
        }

        private string GetPropertyName(LambdaExpression lambdaExpression)
        {
            MemberExpression memberExpression;
            if (lambdaExpression.Body is UnaryExpression)
            {
                UnaryExpression unaryExpression = lambdaExpression.Body as UnaryExpression;
                memberExpression = (unaryExpression.Operand as MemberExpression);
            }
            else
            {
                memberExpression = (lambdaExpression.Body as MemberExpression);
            }
            return memberExpression.Member.Name;
        }
    }
}