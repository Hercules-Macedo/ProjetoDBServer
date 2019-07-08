using AutoMapper;
using ProjetoDBServer.Application.Interfaces;
using ProjetoDBServer.Application.ViewModels;
using ProjetoDBServer.Domain.Entities;
using ProjetoDBServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDBServer.Application
{
    public class ContaCorrenteAppService : IContaCorrenteAppService
    {
        private readonly IMapper _mapper;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteAppService(IMapper mapper, IContaCorrenteRepository contaCorrenteRepository)
        {
            _mapper = mapper;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public string Transferencia(ContaCorrenteViewModel ccOrigemVM, ContaCorrenteViewModel ccDestinoVM, double valor)
        {
            var ccOrigem = _mapper.Map<ContaCorrente>(ccOrigemVM);
            var ccDestino = _mapper.Map<ContaCorrente>(ccDestinoVM);

            return _contaCorrenteRepository.Transferir(ccOrigem, ccDestino, valor);
        }
    }
}
