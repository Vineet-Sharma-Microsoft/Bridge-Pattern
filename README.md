## Introduction

The Bridge design pattern is a structural design pattern used to separate an object's abstraction from its implementation so that both can vary independently. In the context of a fruit application in .NET 7 (Core), I'll provide a simplified example of how you can implement the Bridge pattern.

Let's create an example where we have different types of fruits (abstraction) and different ways to eat them (implementation). The Bridge pattern will help us separate the fruit types from the eating methods.

1. An `Fruit` abstract class representing the abstraction.
2. An `IEatingMethod` interface representing the implementation.
3. Two concrete implementations of `IEatingMethod: BiteEating` and `CutEating`.
4. Two concrete fruits (Apple and Banana) that inherit from the `Fruit` class. Each fruit has a specific eating method injected during instantiation.

This way, you can easily add new fruit types or eating methods without changing existing code, which is the core concept of the Bridge pattern.

# Reference links

- [GitLab CI Documentation](https://docs.gitlab.com/ee/ci/)
- [.NET Hello World tutorial](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/)

If you're new to .NET you'll want to check out the tutorial, but if you're
already a seasoned developer considering building your own .NET app with GitLab,
this should all look very familiar.

## What's contained in this project

The root of the repository contains the out of the `dotnet new console` command,
which generates a new console application that just prints out "Hello, World."
It's a simple example, but great for demonstrating how easy GitLab CI is to
use with .NET. Check out the `Program.cs` and `dotnetcore.csproj` files to
see how these work.

In addition to the .NET Core content, there is a ready-to-go `.gitignore` file
sourced from the the .NET Core [.gitignore](https://github.com/dotnet/core/blob/master/.gitignore). This
will help keep your repository clean of build files and other configuration.

Finally, the `.gitlab-ci.yml` contains the configuration needed for GitLab
to build your code. Let's take a look, section by section.

First, we note that we want to use the official Microsoft .NET SDK image
to build our project.

```
image: microsoft/dotnet:latest
```

We're defining two stages here: `build`, and `test`. As your project grows
in complexity you can add more of these.

```
stages:
    - build
    - test
```

Next, we define our build job which simply runs the `dotnet build` command and
identifies the `bin` folder as the output directory. Anything in the `bin` folder
will be automatically handed off to future stages, and is also downloadable through
the web UI.

```
build:
    stage: build
    script:
        - "dotnet build"
    artifacts:
      paths:
        - bin/
```

Similar to the build step, we get our test output simply by running `dotnet test`.

```
test:
    stage: test
    script: 
        - "dotnet test"
```

This should be enough to get you started. There are many, many powerful options 
for your `.gitlab-ci.yml`. You can read about them in our documentation 
[here](https://docs.gitlab.com/ee/ci/yaml/).

## Developing with Gitpod

This template repository also has a fully-automated dev setup for [Gitpod](https://docs.gitlab.com/ee/integration/gitpod.html).

The `.gitpod.yml` ensures that, when you open this repository in Gitpod, you'll get a cloud workspace with .NET Core pre-installed, and your project will automatically be built and start running.