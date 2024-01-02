using System;
using System.Net.Http.Headers;
using System.Xml.XPath;
using ContactsManager.Core.DTO;
using ContactsManager.Core.Enums;


namespace ContactsManager.Core.ServiceContracts
{
    public interface IPersonAddService
    {
        public Task<PersonResponse> AddPerson(PersonAddRequest request);
        
    }
}
