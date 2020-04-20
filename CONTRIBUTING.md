# Overview
This page sets forth the guidelines and policies for continued development. If you are a new developer, you are welcome to contribute. Read everything here and you shoud feel comfortable contributing code.

If you would like to get started helping, please read everything here and follow the steps under [creating a pull request](#pullreq).


# Table of Contents
* [Dependencies](#dependencies)
* [Branches & versioning](#branches-versioning)
* [Commit guidelines](#commits)
* [Creating a pull request](#pullreq)

# Dependencies
In order to contribute code to this project, install these prerequisites. If you are using a Linux distribution, search your package manager's repository for the applicable packages.
- [.NET Core 2.0+ SDK and Runtime](https://dotnet.microsoft.com/download)
- [Visual Studio Code or Community 2017+](https://visualstudio.microsoft.com/downloads/)

<a name="branches-versioning"></a>
# Branches & version guidelines
## Branch guidelines
This project follows the [Git Flow](https://nvie.com/img/git-model@2x.png) method. If you would like to read more, please see [this page](https://zellwk.com/blog/git-flow/).

## Version guidelines
This project follows Semantic Versioning 2.0.0. With the general convention of MAJOR.MINOR.PATCH:
- MAJOR is incremented when incompatible API changes are introduced.
- MINOR is incremented when backwards-compatible features are introduced.
- PATCH is incremented when bug fixes are introduced.

To read more, please see [this page](https://semver.org/).
<a name="commits"></a>
# Commit guidelines
This project follows [Conventional Commits 1.0.0](https://www.conventionalcommits.org/en/v1.0.0/) for explicit commits and automated tool support.

An example commit:

*fix: fixed an instance of the wrong variable being sent as an argument to SomeMethod()*

*Reviewed-by: Tayne*

The specifics should be further fleshed out in the actual issue being tracked or your pull request. Keep your commit terse.

<a name="pullreq"></a>
# Creating a pull request
If you would like to contribute code, this repository follows the forking workflow to allow anyone to propose changes. If you are unfamiliar, please read [Github's documentation](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request-from-a-fork) and [Atlassian's documentation](https://www.atlassian.com/git/tutorials/comparing-workflows/forking-workflow).

A quick setup guide is as follows:

### Setup a fork for you to work in
- Use Github's UI to fork this repository
- Clone your fork locally: ```$ git clone <url_to_your_fork>```
- Add a remote path to the official repository: ```$ git remote add upstream <url_to_official>```. Use ```$ git fetch upstream``` to sync the two as necessary.
- Make sure you are in the develop branch(default) ```$ git checkout develop```. Now, create your feature branch ```$ git checkout -b <feature_name>```
- When you are done with your commits, use ```$ git push origin <feature_name>```

Now, you are ready to open a pull request.

### Opening a pull request
- See [this article](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request-from-a-fork).
