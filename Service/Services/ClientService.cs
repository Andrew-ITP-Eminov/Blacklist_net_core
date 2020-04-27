using Service.Services;
using Service.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Repository;

namespace WebApplication.Services
{
    public class ClientService : IClientService
    {
        IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<int> UpdateClientDTO(ClientDTO client)
        {
            var model = new Client
            {
                CompanyName = client.ClientCompanyName,
                AgreementNumber = client.ClientAgreementNumber,
                ContactPerson = client.ClientContactPerson,
                PersonInformation =
                {
                    Phone = client.ClientPhone,
                    Status = client.ClientStatus,
                    Email = client.ClientEmail,
                    Note = client.ClientNote,
                    INN = client.ClientINN,
                }
            };
            return await _clientRepository.UpdateClient(model);

        }

        public Task<int> DeleteClientDTO(int? clientId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> AddClientDTO(ClientDTO client)
        {
            var model = new Client {
                CompanyName = client.ClientCompanyName,
                AgreementNumber = client.ClientAgreementNumber,
                ContactPerson = client.ClientContactPerson,
                PersonInformation =
                {
                    Phone = client.ClientPhone,
                    Status = client.ClientStatus,
                    Email = client.ClientEmail,
                    Note = client.ClientNote,
                    INN = client.ClientINN,
                }
            };

          return await _clientRepository.AddClient(model);
        }
        public async Task<ClientDTO> GetClientDTO(int? clientId)
        {
            var model = await _clientRepository.GetClient(clientId);
            var dto = new ClientDTO {
                ClientCompanyName = model.CompanyName,
                ClientAgreementNumber = model.AgreementNumber,
                ClientContactPerson = model.ContactPerson,
                ClientPhone = model.PersonInformation.Phone,
                ClientStatus = model.PersonInformation.Status,
                ClientEmail = model.PersonInformation.Email,
                ClientNote = model.PersonInformation.Note,
                ClientINN = model.PersonInformation.INN,
            };
            return dto;
        }
        public async Task<List<AllClientsDTO>> GetClientsDTO()
        {
            var model = await _clientRepository.GetClients();
            var dtos = new List<AllClientsDTO>();

            foreach (var item in model)
            {
                var dto = new AllClientsDTO
                {
                    ClientId = item.Id,
                    ClientCompanyName = item.CompanyName,
                    ClientAgreementNumber = item.AgreementNumber,
                    ClientContactPerson = item.ContactPerson,
                    ClientPhone = item.PersonInformation.Phone,
                    ClientStatus = item.PersonInformation.Status,
                };
                dtos.Add(dto);
            }

            return dtos;
        }
    }

}
