using System;
using System.Collections.Generic;
using System.Data;
using PIIVault.Shared.Models;

namespace PIIVaultDemoApp.Helpers
{
    public class ProfileHelper
    {
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
                            profile.DateOfBirth = DateTime.Parse(row[col.ColName].ToString());
                        break;
                    case "Gender":
                        if (row[col.ColName] != null)
                            profile.Gender = row[col.ColName].ToString();
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
                            while (addresses.Count  < index + 1) { addresses.Add(new ProfileAddressDTO()); }
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
                    case "Post / Zip Code":
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
    }
}
