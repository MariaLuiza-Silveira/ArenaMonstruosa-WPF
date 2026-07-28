#  Arena Monstruosa

Uma aplicação desktop desenvolvida em **C#** com **WPF**, que permite gerir personagens, simular batalhas automáticas e visualizar a história de cada guerreiro através de uma interface gráfica inspirada no universo medieval.



##  Sobre o projeto

Arena Monstruosa foi desenvolvido como projeto académico com o objetivo de aplicar conceitos de desenvolvimento desktop utilizando WPF, integração com base de dados SQL Server e arquitetura baseada em MVC.

A aplicação permite criar e gerir personagens, realizar batalhas automáticas com base nos atributos de cada jogador e guardar o histórico dos combates efetuados.

---

##  Funcionalidades

-  Gestão completa de jogadores (CRUD)
-  Simulação automática de batalhas
-  Cálculo automático do vencedor
-  Histórico completo de batalhas
-  Janela com história individual de cada personagem
-  Interface gráfica personalizada com tema medieval
-  Integração com SQL Server através do Entity Framework

---

##  Como funciona a batalha

Cada personagem possui quatro atributos:

- Vida (HP)
- Ataque
- Defesa
- Imagem personalizada

O vencedor é calculado automaticamente através da comparação dos atributos dos dois jogadores.

### Fórmula utilizada

```text
Dano = Ataque - Defesa
```

O dano mínimo é sempre 1:

```csharp
Math.Max(1, ataque - defesa);
```

Depois é calculado quantos turnos cada personagem consegue sobreviver:

```text
Turnos = Vida ÷ Dano recebido
```

O personagem que sobreviver durante mais turnos é declarado vencedor.

---

##  Tecnologias utilizadas

- C#
- WPF
- XAML
- .NET Framework 4.8
- SQL Server
- Entity Framework
- MVC
- Visual Studio 2022

---

##  Estrutura do projeto

```
ArenaMonstruosa
│
├── Controllers
│   └── JogadorController.cs
│
├── Data
│   └── GameContext.cs
│
├── Models
│   ├── Jogador.cs
│   ├── Batalha.cs
│   └── BatalhaView.cs
│
├── Imagens
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
│
├── HistoriaWindow.xaml
├── HistoriaWindow.xaml.cs
│
└── ArenaMonstruosa.sln
```

---

##  Funcionalidades implementadas

### Gestão de Jogadores

- Adicionar jogador
- Editar jogador
- Eliminar jogador
- Limpar formulário
- Listagem em DataGrid

### Arena

- Seleção de dois jogadores
- Visualização dos atributos
- Simulação da batalha
- Exibição do vencedor
- Atualização automática do histórico

### História

- Navegação entre personagens
- História individual
- Mudança dinâmica das cores da interface
- Navegação por botões Anterior e Próximo

---

##  Base de Dados

O projeto utiliza SQL Server e Entity Framework.

### Tabelas

- Jogadores
- Batalhas

A tabela **Batalhas** possui relacionamento com a tabela **Jogadores**, permitindo guardar:

- Jogador 1
- Jogador 2
- Vencedor
- Data da batalha

---

##  Interface

A interface foi totalmente personalizada utilizando WPF e XAML.

Entre as personalizações encontram-se:

- Botões em formato de imagem
- Ícones personalizados
- ScrollBars personalizadas
- ComboBox personalizada
- DataGrid personalizada
- Efeitos de brilho (Glow)
- Tema medieval
- Layout responsivo

---

##  Capturas de ecrã

### Menu principal

<img width="777" height="505" alt="Tela_Principal" src="https://github.com/user-attachments/assets/e76bce0d-ed96-434e-878c-2e9dbe78506d" />

---

### Gestão de jogadores

<img width="419" height="288" alt="Gestao_Jogadores1" src="https://github.com/user-attachments/assets/dd272906-e0af-403c-9fec-ac3d54f061ce" />
<img width="419" height="285" alt="Gestao_Jogadores2" src="https://github.com/user-attachments/assets/8f50eaed-f983-463f-94ee-4221bb50abbe" />


---
### Histórico de batalhas

<img width="416" height="169" alt="Historico_Batalhas" src="https://github.com/user-attachments/assets/6271495b-a38f-4ff7-bc26-0772003a6c1b" />

---

### Arena de batalha

<img width="346" height="260" alt="Arena_Batalha" src="https://github.com/user-attachments/assets/d4b70ca8-9f87-4362-bacd-dc6d416e3532" />

---

### Resultado da batalha

<img width="341" height="131" alt="Resultado_Batalha1" src="https://github.com/user-attachments/assets/ff161f5c-6ace-4a48-b1dc-5d70bc2c51e2" />
<img width="341" height="128" alt="Resultado_Batalha2" src="https://github.com/user-attachments/assets/b62abb32-c39a-4bf5-940b-9d6e473b0841" />
<img width="339" height="128" alt="Resultado_Batalha3" src="https://github.com/user-attachments/assets/a5b3d06d-a9b7-4974-9dc4-1c9dfc95c870" />
<img width="121" height="170" alt="Resultado_Batalha4" src="https://github.com/user-attachments/assets/e14e8c0e-1a84-4f5e-bb04-ad84d52238c4" />

---

### História dos personagens

<img width="776" height="505" alt="Personagem_Fada" src="https://github.com/user-attachments/assets/661de419-cb38-4a81-944b-1a1cf0267bef" />
<img width="774" height="503" alt="Personagem_Dragao" src="https://github.com/user-attachments/assets/ee7524d7-e40a-4657-b45d-f57f34ce5694" />
<img width="778" height="501" alt="Personagem_Orc" src="https://github.com/user-attachments/assets/04b2a798-0dda-4f43-8465-13b1eee2095d" />
<img width="779" height="500" alt="Personagem_Cavaleiro" src="https://github.com/user-attachments/assets/727ab407-5aad-44af-a9b2-27e43f25c036" />
<img width="775" height="506" alt="Personagem_Feiticeiro" src="https://github.com/user-attachments/assets/113a6d0e-a6ec-419a-8ac2-fe64244dcd33" />
<img width="779" height="501" alt="Personagem_Elfo" src="https://github.com/user-attachments/assets/4041c729-e3ad-47bc-9ef4-a6f6ca1296d1" />
<img width="777" height="503" alt="Personagem_Troll" src="https://github.com/user-attachments/assets/dc3bae46-394b-41c8-b75f-73e6863fbb5f" />
<img width="777" height="501" alt="Personagem_Rei" src="https://github.com/user-attachments/assets/b67ee453-2015-4fc9-a51d-eaeb99575bb4" />
<img width="775" height="501" alt="Personagem_Duende" src="https://github.com/user-attachments/assets/796f726b-9e50-4712-8515-09ae9de14841" />
<img width="776" height="500" alt="Personagem_Gigante" src="https://github.com/user-attachments/assets/db67bd02-10a4-407c-9741-c9f8e8ce13ed" />


---

##  Aprendizagens

Durante o desenvolvimento deste projeto foram aplicados conhecimentos de:

- Programação Orientada a Objetos
- Arquitetura MVC
- Desenvolvimento Desktop com WPF
- XAML
- Entity Framework
- SQL Server
- CRUD
- Manipulação de imagens
- Eventos
- Interface gráfica
- Integração entre aplicação e base de dados

---

##  Autora

**Maria Silveira**

Estudante de Engenharia Informática

Portugal 🇵🇹
