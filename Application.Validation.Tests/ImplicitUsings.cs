﻿global using FluentAssertions;
global using NUnit;
global using TechTalk.SpecFlow;
global using Formation.Application.Books.Commands;
global using Formation.Application.Repositories;
global using Formation.Application.Books.Commands.CreateBook;
global using Formation.Application.Authors.Commands.CreateAuthor;
global using Formation.Domain.Entities;
global using System.Linq;
global using Application.Validation.Tests.Drivers;
global using NUnit.Framework;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection;
global using Moq;
global using Application.Validation.Tests.Extentions;