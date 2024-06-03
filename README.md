

# Taking_Kubernetes

<h1  align="center">Exercício do treinamento Kubernetes T1</h1>

<h3  align="center">Estacionamento com .NET 8 - C#, Docker, Minikube e Kubectl</h3>

<p  align="center">

![Badge](https://img.shields.io/badge/license-MIT-brightgreen?style=flat)  ![Badge](https://img.shields.io/badge/build-sucess-brightgreen?style=flat)
</p>


# Sumário

<!--ts-->

-  [Ferramentas utilizadas](#ferramentas-utilizadas)

-  [Imagnes e Dashboard](#imagens-e-dashboard)

-  [Executando Manifesto](#executar-manifesto)

-  [Autor(a)](#autora)

<!--te-->

---
<h4  align="center"> Estacionamento Web - 🚧 Em construção🚧 </h4>

---

# Ferramentas utilizadas

 ⚠️OS: Windows_NT x64 10.0.22631


🛠 Desenvolvimento:

	✅ Microsoft Visual Studio Community 2022- v 17.10.1

	✅ Visual Code - v 1.89.1

	✅ DBeaver - v 24.0.5


🛠 Deploy:

	✅ Docker versão 26.0.1

	✅ Minikube versão 1.33.0

	✅ Kubectl - Client Version: 1.30.0

	✅ Git Bash
  
<p  align="left">

<a  href=""  target="_blank"  rel="noreferrer"><img  src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg"  alt="csharp"  width="40"  height="40"/></a>  <a  href="https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.406-windows-x64-installer"  target="_blank"  rel="noreferrer"><img  src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg"  alt="dotnet"  width="40"  height="40"/></a>  <a  href="https://docs.docker.com/desktop/install/windows-install/"  target="_blank"  rel="noreferrer"><img  src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg"  alt="git"  width="40"  height="40"/></a>  <a  href="https://postman.com"  target="_blank"  rel="noreferrer"></a>  </p>

---

# Imagens e Dashboard

⚠️Abra :

👉 Com o visual code usando o terminal com Git Bash 

```bash

# Digite caminho do projeto onde está o shell script minikube.sh
exemplo:  cd  Estacionamento

# Após entrar na pasta digite o comando para executar o shell e start o minikube
sh  minikube.sh

# Ao start o minikube executar o shell script das imagens imagemEstacionamento.sh será criado as imagens do projeto API e Console para criar a database e tabelas iniciais.
sh  imagemEstacionamento.sh

# Ao ter sucesso na criação abra o Dashboard para verificar se todos os pods foram criados com sucesso
minikube  dashboard

```
---

## Executar Manifesto

👉 Novo termina do visual code:
```bash

# Entre na pasta Estacionamento/k8s
cd  Estacionamento/k8s

# Execute o script apply.sh
sh  apply.sh

# Este shell script contém o comando aplly do kubectl, onde irá aplicar os seguintes manifestos.
	➡️  namespace.yaml
	➡️  secret.yaml  -  Contém  a  senha  do  banco  de  dados
	➡️  configmap.yaml  -  Contém  a  conexão  do  banco  de  dados  e  a  variavel  apsnetcore_environment  usada  na  API)

	📁  Base (Banco de  Dados)
		➡️  statefulSet.yaml  -  Aplicação  banco  de  dados  SQLServe  2019
		➡️  service.yaml  -  Porta  exposta  para  usar  em  outras  ferramentas
		➡️  job.yaml  -  Aplicação  da  Console  aplicação  criando  a  base  de  dados  e  tabelas

	📁Aplication (API)
		➡️  deployment.yaml  -  Aplicação  da  API
		➡️  service.yaml  -  Expondo  a  API  para  ser  acessada  pelo  bowser

```
👉 No DBeaver acesso o banco SqlServer pela url: localhost:31000 - Username: sa

👉 No browser acesse a API pela a url: http://localhost:31001/swagger/index.html

---
## Autor(a)

Angelica Dupim