using System;
using System.Collections.Generic;
using System.Data;
using PIIVault.Shared.Models;

namespace PIIVaultDemoApp.Helpers
{
    public class ProfileHelper
    {
        /*  this class is used to serialize and deserialize a data row based on the definition of the
         *  schema as provided in the list of pii columns
         */
           
        public ProfileRequestDTO BuildProfile(DataRow row, List<PiiCol> piiCols, int profileIndex)
        {
            ProfileRequestDTO profile = new ProfileRequestDTO();
            profile.Index = profileIndex;

            // initialize all the lists used to populate profile arrays 
            List<ProfilePhoneDTO> phones = new List<ProfilePhoneDTO>();
            List<ProfileEmailDTO> emails = new List<ProfileEmailDTO>();
            List<ProfileKeyDTO> keys = new List<ProfileKeyDTO>();
            List<ProfileAddressDTO> addresses = new List<ProfileAddressDTO>();

            foreach (PiiCol col in piiCols)
            {
                int index = Convert.ToInt32(col.ColGroup);
                switch (col.PiiType)
                {
                    case "Unique Key to Individual":
                        if (row[col.ColName] != null)
                            profile.SourceSystemKey = row[col.ColName].ToString();
                        break;
                    case "First Name":
                        if (row[col.ColName] != null)
                            profile.FirstName = row[col.ColName].ToString();
                        break;
                    case "Middle Name":
                        if (row[col.ColName] != null)
                            profile.MiddleName = row[col.ColName].ToString();
                        break;
                    case "Last Name":
                        if (row[col.ColName] != null)
                            profile.LastName = row[col.ColName].ToString();
                        break;
                    case "Date of Birth":
                        if (row[col.ColName] != null)
                        {
                            string test = row[col.ColName].ToString();
                            DateTime dt = DateTime.Parse(test);
                            profile.DateOfBirth = DateTime.Parse(row[col.ColName].ToString());
                        }  
                        break;
                    case "Gender":
                        if (row[col.ColName] != null)
                            profile.Gender = row[col.ColName].ToString();
                        break;
                    case "Organization Name":
                        if (row[col.ColName] != null)
                            profile.OrgName = row[col.ColName].ToString();
                        break;
                    case "Phone Number":
                        if (row[col.ColName] != null)
                        {
                            while (phones.Count < index + 1) { phones.Add(new ProfilePhoneDTO()); }
                            phones[index].PhoneNumber = row[col.ColName].ToString();
                        }
                        break;
                    case "Phone Type (Home/Cell/Work)":
                        if (row[col.ColName] != null)
                        {
                            while (phones.Count < index + 1) { phones.Add(new ProfilePhoneDTO()); }
                            phones[index].PhoneNumber = row[col.ColName].ToString();
                        }
                        break;
                    case "Email Address":
                        if (row[col.ColName] != null)
                        {
                            while (emails.Count < index + 1) { emails.Add(new ProfileEmailDTO()); }
                            emails[index].EmailAddress = row[col.ColName].ToString();
                        }
                        break;
                    case "Type of Address":
                        if (row[col.ColName] != null)
                        {
                            while (addresses.Count < index + 1) { addresses.Add(new ProfileAddressDTO()); }
                            addresses[index].AddressType = row[col.ColName].ToString();
                        }
                        break;
                    case "Address Line 1":
                        if (row[col.ColName] != null)
                        {
                            while (addresses.Count < index + 1) { addresses.Add(new ProfileAddressDTO()); }
                            addresses[index].StreetAddress1 = row[col.ColName].ToString();
                        }
                        break;
                    case "Address Line 2":
                        if (row[col.ColName] != null)
                        {
                            while (addresses.Count < index + 1) { addresses.Add(new ProfileAddressDTO()); }
                            addresses[index].StreetAddress2 = row[col.ColName].ToString();
                        }
                        break;
                    case "Address Line 3":
                        if (row[col.ColName] != null)
                        {
                            while (addresses.Count < index + 1) { addresses.Add(new ProfileAddressDTO()); }
                            addresses[index].StreetAddress3 = row[col.ColName].ToString();
                        }
                        break;
                    case "Address Line 4":
                        if (row[col.ColName] != null)
                        {
                            while (addresses.Count < index + 1) { addresses.Add(new ProfileAddressDTO()); }
                            addresses[index].StreetAddress4 = row[col.ColName].ToString();
                        }
                        break;
                    case "City":
                        if (row[col.ColName] != null)
                        {
                            while (addresses.Count < index + 1) { addresses.Add(new ProfileAddressDTO()); }
                            addresses[index].City = row[col.ColName].ToString();
                        }
                        break;
                    case "State / State Code":
                        if (row[col.ColName] != null)
                        {
                            while (addresses.Count < index + 1) { addresses.Add(new ProfileAddressDTO()); }
                            addresses[index].StateCode = row[col.ColName].ToString();
                        }
                        break;
                    case "Zip / Postal Code":
                        if (row[col.ColName] != null)
                        {
                            while (addresses.Count < index + 1) { addresses.Add(new ProfileAddressDTO()); }
                            addresses[index].PostalCode = row[col.ColName].ToString();
                        }
                        break;
                    case "County":
                        if (row[col.ColName] != null)
                        {
                            while (addresses.Count < index + 1) { addresses.Add(new ProfileAddressDTO()); }
                            addresses[index].County = row[col.ColName].ToString();
                        }
                        break;
                    case "Country":
                        if (row[col.ColName] != null)
                        {
                            while (addresses.Count < index + 1) { addresses.Add(new ProfileAddressDTO()); }
                            addresses[index].Country = row[col.ColName].ToString();
                        }
                        break;
                    case "Additional Key Type (SSN/DL#/Etc.)":
                        if (row[col.ColName] != null)
                        {
                            while (keys.Count < index + 1) { keys.Add(new ProfileKeyDTO()); }
                            keys[index].KeyType = row[col.ColName].ToString();
                        }
                        break;
                    case "Additional Key Value":
                        if (row[col.ColName] != null)
                        {
                            while (keys.Count < index + 1) { keys.Add(new ProfileKeyDTO()); }
                            keys[index].KeyValue = row[col.ColName].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }


            // ############## Phone Numbers ###################

            if (phones.Count > 0)
            {
                profile.Phones = phones.ToArray();
            }

            // ############## Emails ###################
            if (emails.Count > 0)
            {
                profile.Emails = emails.ToArray();
            }

            //// ############## Keys ###################
            if (keys.Count > 0)
            {
                profile.Keys = keys.ToArray();
            }

            // ############## Addresses ###################
            if (addresses.Count > 0)
            {
                profile.Addresses = addresses.ToArray();
            }

            return profile;
        }
        public DataRow MaskRowPii(ProfileResponseDTO profile, List<PiiCol> piiCols, DataRow newRow)
        {

            foreach (PiiCol col in piiCols)
            {
                int index = Convert.ToInt32(col.ColGroup);
                switch (col.PiiType)
                {
                    case "Unique Key to Individual":
                        newRow[col.ColName] = profile.SourceSystemKey;
                        break;
                    case "First Name":
                        newRow[col.ColName] = profile.FirstName;
                        break;
                    case "Middle Name":
                        newRow[col.ColName] = profile.MiddleName;
                        break;
                    case "Last Name":
                        newRow[col.ColName] = profile.LastName;
                        break;
                    case "Date of Birth":
                        newRow[col.ColName] = profile.DateOfBirth;
                        break;
                    case "Gender":
                        newRow[col.ColName] = profile.Gender;
                        break;
                    case "Phone Number":
                        newRow[col.ColName] = profile.Phones[Int16.Parse(col.ColGroup)].PhoneNumber;
                        break;
                    case "Phone Type (Home/Cell/Work)":
                        newRow[col.ColName] = profile.Phones[Int16.Parse(col.ColGroup)].PhoneType;
                        break;
                    case "Email Address":
                        newRow[col.ColName] = profile.Emails[Int16.Parse(col.ColGroup)].EmailAddress;
                        break;
                    case "Type of Address":
                        newRow[col.ColName] = profile.Addresses[Int16.Parse(col.ColGroup)].AddressType;
                        break;
                    case "Address Line 1":
                        newRow[col.ColName] = profile.Addresses[Int16.Parse(col.ColGroup)].StreetAddress1;
                        break;
                    case "Address Line 2":
                        newRow[col.ColName] = profile.Addresses[Int16.Parse(col.ColGroup)].StreetAddress2;
                        break;
                    case "Address Line 3":
                        newRow[col.ColName] = profile.Addresses[Int16.Parse(col.ColGroup)].StreetAddress3;
                        break;
                    case "Address Line 4":
                        newRow[col.ColName] = profile.Addresses[Int16.Parse(col.ColGroup)].StreetAddress4;
                        break;
                    case "City":
                        newRow[col.ColName] = profile.Addresses[Int16.Parse(col.ColGroup)].City;
                        break;
                    case "State / State Code":
                        newRow[col.ColName] = profile.Addresses[Int16.Parse(col.ColGroup)].StateCode;
                        break;
                    case "Zip / Postal Code":
                        newRow[col.ColName] = profile.Addresses[Int16.Parse(col.ColGroup)].PostalCode;
                        break;
                    case "County":
                        newRow[col.ColName] = profile.Addresses[Int16.Parse(col.ColGroup)].County;
                        break;
                    case "Country":
                        newRow[col.ColName] = profile.Addresses[Int16.Parse(col.ColGroup)].Country;
                        break;
                    case "Additional Key Type (SSN/DL#/Etc.)":
                        newRow[col.ColName] = profile.Keys[Int16.Parse(col.ColGroup)].KeyType;
                        break;
                    case "Additional Key Value":
                        newRow[col.ColName] = profile.Keys[Int16.Parse(col.ColGroup)].KeyValue;
                        break;
                    default:
                        break;
                }
            }
            return newRow;
        }
    }
}
