# ParkNet

Título e Descrição: ParkNet é um projecto realizado no âmbito do Curso ReStart pela Academia Cegid - Primavera, para o módulo de C#. Pretende-se que seja um programa para gestão de parques de estacionamento onde os user poderão ter uma conta, carregar saldo e comprar passes ou bilhete de utilização única.

Instruções de Instalação: O admin deverá registar-se com o e-mail admin@parknet.pt para que possa aceder às suas funcionalidades exclusivas.

Como Usar: O administrador deve começar por registar os preços para todos os tipos de veículos, avenças e períodos de tempo. 
Deve também adicionar os parques de estacionamento com os respectivos dados e layout. na ImageData deve ser fornecido um link com uma foto referente ao parque de estacionamento.
Os Layouts devem ter a seguinte estrutura:

C MMMM C
M CCCC M
.
M CCCC M
C MMMM C

Cada letra corresponde a um espaço de estacionamento sendo C para Carros e M para Motas. O ponto final (".") refere-se à mudança de piso.
No que diz respeito às Permits, podem ser compradas no separador Buy e estão válidas no período de tempo definido. Relativamente aos tickets, quando se compra apenas se selecciona o parque e o veículo e é atribuído um número de bilhete. Esse número é usado para fazer In e Out e só nestas alturas é que são calculados os timings, preços, escolhido o piso e o lugar e feita a transação.

Status do Projeto: O projecto possuí maioria das funcionalidades, mas foi construído por uma pessoa em tenra aprendizagem, enquanto trabalha fulltime noutra área, pelo que se encontra com muitas falhas, nomeadamente:
- Ausência de validações
- Ausência de protecção para overposting
- Ausência de maneio de excepções
- Nem todos os métodos foram convertidos em Async
- Não consegui fazer testes
- Validação de saldos positivos para efectuar transações

Contato: mjoaodourado@gmail.com
