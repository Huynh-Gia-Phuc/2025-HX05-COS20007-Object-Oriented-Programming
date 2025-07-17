using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class IdentifiableObject
    {
        // Private field
        private List<string> _identifiers;

        private const string StudentId = "SWS01358"; 
        private const string TutorialId = "2106";
        private string _StudentIdLast4Digits = string.Empty;
        //get last 4 digit
        private void GetLast4Digits()
        {
            _StudentIdLast4Digits = StudentId.Substring(StudentId.Length - 4);
        }

        // Constructor
        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>(); // Initialize an empty list
            foreach (string id in idents) // Loop through the input array
            {
                _identifiers.Add(id.ToLower()); // Add the lowercase version
            }
            GetLast4Digits(); // Keep this call if it's needed
        }

        // Public method: AreYou
        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        } 

        // Readonly property: FirstId
        public string FirstId
        {
            get
            {
                // Check if the _identifiers list has any elements
                if (_identifiers.Count > 0)
                {
                    // If it does, return the first item in the list
                    return _identifiers[0];
                }
                else
                {
                    // If the list is empty, return an empty string
                    return string.Empty;
                }
            }
        }

        // Public method: AddIdentifier
        public void AddIdentifier(string id)
        {   
            _identifiers.Add(id.ToLower());
        }

        // Public method: PrivilegeEscalation
        public void PrivilegeEscalation(string pin)
        {
            if (pin == _StudentIdLast4Digits && _identifiers.Count > 0)
            {
                _identifiers[0] = TutorialId.ToLower();
            }
        }
    }
}
