using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp.FieldValidators
{
    public delegate bool FieldValidorDelegate(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage);
    public interface IFieldValidator
    {
        void InitializeFieldValidators();
        string[] FieldArray { get;}
        FieldValidorDelegate Validator { get; }

    }
}
