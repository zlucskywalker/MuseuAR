# Museu Virtual AR - Experiência Gamificada
## Disciplina: Computação Gráfica - Engenharia da Computação
## Alunos: Manoel Lucas Pacheco Junior (20250071269) || Gabriel Mesquita Torres (2022020390)

## Sumário
- [Sobre o Projeto](#-sobre-o-projeto)
- [Funcionalidades Principais](#-funcionalidades-principais)
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Arquitetura da Solução](#-arquitetura-da-solução)
- [Como Utilizar (Guia do Usuário)](#-como-utilizar-guia-do-usuário)
- [Acervo Virtual](#-acervo-virtual)
- [Instalação e Build](#-instalação-e-build)
- [Autor](#-autor)

---

## Sobre o Projeto

O **Museu Virtual AR** é uma aplicação de Realidade Aumentada desenvolvida para dispositivos móveis, cujo objetivo é dar um pequeno acesso à arte clássica e moderna através da tecnologia imersiva.

Este projeto implementa um **Conceito de "Janela Viva"**: ao apontar a câmera para o meio físico, o usuário não vê apenas uma imagem 2D, mas sim **Molduras 3D flutuando no espaço**, contendo as obras de arte, simulando a experiência física de estar diante de um quadro numa exposição.

Além da visualização, o projeto integra **Gamificação (Quiz)** para testar o conhecimento do usuário sobre a obra exibida.

##  Funcionalidades Principais

### 1. Renderização de Molduras 3D 
Utilização de modelos tridimensionais de molduras clássicas que se sobrepõem aos marcadores físicos.
- **Interatividade:** O usuário pode andar em volta da obra, dando a sensação de que ela realmente está ali flutuando.
- **Oclusão e Escala:** Ajuste dinâmico de tamanho baseada na distância da câmera.

### 2. Sistema de Quiz Contextual
Interface de Usuário (UI) integrada que reconhece qual obra está sendo exibida e gera perguntas específicas.
- **Feedback Imediato:** O sistema valida a resposta (Certo/Errado) visualmente em tempo real.
- **Score System:** Contabilização de acertos ao final da visitação.

### 3. Rastreamento Estável (Vuforia)
Uso de *Image Targets* de alto contraste para garantir que a obra permaneça fixa no mundo real mesmo com movimentos bruscos do dispositivo.

---

## Tecnologias Utilizadas

* **Engine:** Unity 2022.3 LTS (Versão Long Term Support para estabilidade Android).
* **AR Framework:** Vuforia Engine (SDK 10.x ou superior).
* **Linguagem:** C# (.NET Standard 2.1).
* **Assets:**
    * Low Poly Picture Frames (Otimizados para mobile).
    * Texturas em Alta Definição (HD) das pinturas.

---

## Como Utilizar (Guia do Usuário)

1.  **Instalar:** Abra o instalador `install_MuseuAR.apk` a aba **Releases** deste repositório.
2.  **ABRIR:** Abra o aplicativo `MuseuAR`.
4.  **Visualizar:** A obra 3D surgirá sobre a imagem. Mova o celular ao redor para ver detalhes da moldura e da textura.
5.  **Jogar:** Leia a pergunta que aparecerá no rodapé da tela e selecione a alternativa correta sobre o autor ou o movimento artístico.

---

## Acervo Virtual

O aplicativo suporta o reconhecimento simultâneo de **8 Obras-Primas**, incluindo clássicos internacionais e ícones do modernismo brasileiro.

Abaixo a relação dos alvos configurados na Database do Vuforia:

| ID | Imagem Alvo | Obra (Pintura) | Autor | Pergunta do Quiz |
|:--:|:------------|:---------------|:------|:-----------------|
| 01 | `Obra1.jpg` | **Mona Lisa** | Leonardo da Vinci | "Quem pintou esta obra?" |
| 02 | `Obra2.jpg` | **O Grito** | Edvard Munch | "Qual o movimento artístico?" |
| 03 | `Obra3.jpg` | **A Noite Estrelada** | Vincent van Gogh | "Onde o pintor estava?" |
| 04 | `Obra4.jpg` | **Abaporu** | Tarsila do Amaral | "Qual movimento inspirou?" |
| 05 | `Obra5.jpg` | **As Meninas** | Diego Velázquez | "Qual o estilo da obra?" |
| 06 | `Obra6.jpg` | **Os Retirantes** | Candido Portinari | "O que a obra denuncia?" |
| 07 | `Obra7.jpg` | **O Almoço dos Barqueiros** | Renoir | "Qual o movimento artístico?" |
| 08 | `Obra8.jpg` | **A Persistência da Memória** | Salvador Dalí | "O que são os relógios?" |

---

## Arquitetura da Solução

Estrutura de pastas do projeto Unity:

* `Assets/` - Scripts, Cenas, Prefabs, Modelos 3D e Materiais.
* `Packages/` - Dependências do projeto (Manifesto do Unity).
* `ProjectSettings/` - Configurações de Input, Tags, Physics e Vuforia.

### Organização da Pasta Assets
```text
Assets/
│
├── _Scenes/         # Cena principal (SampleScene.unity)
├── Scripts/         # Lógica do jogo (QuizManager, GaleriaManager, PosicionadorAR)
├── Prefabs/         # Objetos 3D configurados (Obras com moldura)
├── Materials/       # Materiais das molduras e texturas
├── Models/          # Arquivos .fbx originais
├── Textures/        # Imagens das obras (Mona Lisa, O Grito, etc.)
└── Resources/       # Assets carregados dinamicamente
```

---

## Instalação e Build

### Requisitos
* Android 7.0 (Nougat) ou superior.
* Câmera traseira funcional.
* Permissão de instalação de fontes desconhecidas (para APK externo).

### Passo a Passo
1.  Baixe o arquivo `install_MuseuAR.apk` na aba **Releases** deste repositório.
2.  Transfira para o celular e instale.
3.  Ao abrir, conceda permissão de uso da **Câmera**.

---

## Autores

**Manoel Lucas Pacheco Junior** e **Gabriel Mesquita Torres**
* **Curso:** Engenharia da Computação - UFMA
* **Disciplina:** Computação Gráfica (2026.1)


---
*Projeto desenvolvido para fins educacionais.*
