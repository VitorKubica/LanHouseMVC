# 💻 Projeto de LanHouse - C#
Seja bem-vindo ao repositório do nosso projeto LanHouse, desenvolvido para o Checkpoint 2 da matéria de C#

## 🤝 Integrantes
<table>
    <td align="center">
      <p>RM551809</p>
      <a href="https://github.com/nichol6s">
        <img src="https://avatars.githubusercontent.com/u/105325313?v=4" width="115px;" alt="Foto do Nicholas no GitHub"/><br>
        <sub>
          <strong>Nicholas Santos</strong>
        </sub>
      </a>
    </td>
    <td align="center">
      <p>RM98903</p>
      <a href="https://github.com/VitorKubica">
        <img src="https://avatars.githubusercontent.com/u/107961081?v=4" width="115px;" alt="Foto do Vitor no GitHub"/><br>
        <sub>
          <strong>Vitor Kubica</strong>
        </sub>
      </a>
    </td>
</table>

## 🚀 Arquitetura do Projeto

    lanhuse - 5 entidades
    computador - int Id, string Nome
    perifericos - int Id, string tipo, string marca, int ComputadorId
    cliente -  int Id, string nome, string CPF
    InfoContato - int Id, string Telefone, string Email, ClienteId
    reserva - int Id ,computador Computador, cliente Cliente, dateTime Data
    
    computador - perifericos 1-n
    resreva - cliente 1-n
    reserva - computador 1-n
    cliente - InfoContato 1-1

    crud Computador
    crud perifericos
    crud cliente
    crud InfoContato 
    crud reserva


