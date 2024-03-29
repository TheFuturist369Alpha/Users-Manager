﻿using System;
using ContactsManager.Core.ServiceContracts;
using ContactsManager.Core.DTO;
using ContactsManager.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using ContactsManager.Core.Enums;
using ContactsManager.Core.RepoContracts;


namespace Services
{
    public class SortedPersonService : IPersonSortedService
    { 
        public async Task<List<PersonResponse>> GetSortedPersons(List<PersonResponse> all, string sortby, SortOrder x)
        {
           
            if (!string.IsNullOrEmpty(sortby))
                return all;
            List<PersonResponse> sorted = (sortby, x) switch
            {
                (nameof(PersonResponse.Name),SortOrder.Asc)=>all.OrderBy(temp =>temp.Name,StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Name), SortOrder.Desc) => all.OrderByDescending(temp => temp.Name, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrder.Asc)=> all.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Email), SortOrder.Desc) => all.OrderByDescending(temp => temp.Name, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Password), SortOrder.Asc) => all.OrderBy(temp => temp.Password, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Password) , SortOrder.Desc) => all.OrderByDescending(temp => temp.Password, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrder.Asc) => all.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Address), SortOrder.Desc) => all.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Age), SortOrder.Asc) => all.OrderBy(temp => temp.Age).ToList(),
                (nameof(PersonResponse.Age), SortOrder.Desc) => all.OrderByDescending(temp => temp.Age).ToList(),

                (nameof(PersonResponse.country), SortOrder.Asc) => all.OrderBy(temp => temp.country, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.country), SortOrder.Desc) => all.OrderByDescending(temp => temp.country, StringComparer.OrdinalIgnoreCase).ToList(),

                _=>all

            };
            return sorted;
        }

       
    }
}
