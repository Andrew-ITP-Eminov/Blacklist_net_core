using AutoMapper;
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, Client>()
                      .ForMember(d => d.PersonInformation, opt => opt.MapFrom(c => new PersonInformation
                      {
                          Phone = c.Phone,
                          Status = c.Status,
                          Email = c.Email,
                          Note = c.Note,
                          INN = c.INN,
                      })));

            var mapper = new Mapper(config);
            Client data = mapper.Map<ClientDTO, Client>(client);

            return await _clientRepository.UpdateClient(data);

            /*
            var model = new Client
            {
                CompanyName = client.CompanyName,
                AgreementNumber = client.AgreementNumber,
                ContactPerson = client.ContactPerson,
                PersonInformation =
                {
                    Phone = client.Phone,
                    Status = client.Status,
                    Email = client.Email,
                    Note = client.Note,
                    INN = client.INN,
                }
            };
            return await _clientRepository.UpdateClient(model);
            */
        }

        public async Task<int> DeleteClientDTO(int? clientId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>());
                             
            var mapper = new Mapper(config);
            var client = mapper.Map<int>(await _clientRepository.DeleteClient(clientId));
            return client;


            // return await _clientRepository.DeleteClient(clientId);
        }

        public async Task<int> AddClientDTO(ClientDTO client)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, Client>()
                      .ForMember(d => d.PersonInformation, opt => opt.MapFrom(c => new PersonInformation {
                          Phone = c.Phone,
                          Status = c.Status,
                          Email = c.Email,
                          Note = c.Note,
                          INN = c.INN,
                      })));

            var mapper = new Mapper(config);
            Client data = mapper.Map<ClientDTO, Client>(client);

            return await _clientRepository.AddClient(data);


            /*
            var model = new Client {
                CompanyName = client.CompanyName,
                AgreementNumber = client.AgreementNumber,
                ContactPerson = client.ContactPerson,
                PersonInformation =
                {
                    Phone = client.Phone,
                    Status = client.Status,
                    Email = client.Email,
                    Note = client.Note,
                    INN = client.INN,
                }
            };
            return await _clientRepository.AddClient(model);
            */
        }
        public async Task<ClientDTO> GetClientDTO(int? clientId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()
                               .ForMember("Phone", opt => opt.MapFrom(c => c.PersonInformation.Phone))
                               .ForMember("Status", opt => opt.MapFrom(c => c.PersonInformation.Status))
                               .ForMember("Email", opt => opt.MapFrom(c => c.PersonInformation.Email))
                               .ForMember("Note", opt => opt.MapFrom(c => c.PersonInformation.Note))
                               .ForMember("INN", opt => opt.MapFrom(c => c.PersonInformation.INN)));

            var mapper = new Mapper(config);
            var clients = mapper.Map<ClientDTO>(await _clientRepository.GetClient(clientId));
            return clients;

            /*
             var model = await _clientRepository.GetClient(clientId);
             var dto = new ClientDTO {
                 CompanyName = model.CompanyName,
                 AgreementNumber = model.AgreementNumber,
                 ContactPerson = model.ContactPerson,
                 Phone = model.PersonInformation.Phone,
                 Status = model.PersonInformation.Status,
                 Email = model.PersonInformation.Email,
                 Note = model.PersonInformation.Note,
                 INN = model.PersonInformation.INN,
             };
             return dto;
             */
        }
        public async Task<List<AllClientsDTO>> GetClientsDTO(int currentPage, int PageSize)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, AllClientsDTO>()
                               .ForMember("Phone", opt => opt.MapFrom(c => c.PersonInformation.Phone))
                               .ForMember("Status", opt => opt.MapFrom(c => c.PersonInformation.Status)));

            var mapper = new Mapper(config);
            var clients = mapper.Map<List<AllClientsDTO>>(await _clientRepository.GetClients(currentPage, PageSize)) ;
            return clients;

            /*
            var model = await _clientRepository.GetClients();
            var dtos = new List<AllClientsDTO>();

            foreach (var item in model)
            {
                var dto = new AllClientsDTO
                {
                    Id = item.Id,
                    CompanyName = item.CompanyName,
                    AgreementNumber = item.AgreementNumber,
                    ContactPerson = item.ContactPerson,
                    Phone = item.PersonInformation.Phone,
                    Status = item.PersonInformation.Status,
                };
                dtos.Add(dto);
            }
            return dtos;
            */
        }

        public async Task<List<AllClientsDTO>> SearchByDTO(int currentPage, int PageSize, string Keyword)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, AllClientsDTO>()
                              .ForMember("Phone", opt => opt.MapFrom(c => c.PersonInformation.Phone))
                              .ForMember("Status", opt => opt.MapFrom(c => c.PersonInformation.Status)));

            var mapper = new Mapper(config);
            var clients = mapper.Map<List<AllClientsDTO>>(await _clientRepository.GetSearchBy(currentPage, PageSize, Keyword));
            return clients;
        }
    }

}
