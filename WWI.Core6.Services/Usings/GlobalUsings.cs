global using System;
global using System.Linq;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Collections.Generic;

global using MediatR;
global using FluentValidation;
global using Ardalis.GuardClauses;

global using WWI.Core6.Models.ViewModels;
global using WWI.Core6.Services.MediatR.Queries;
global using WWI.Core6.Services.ServiceCollection;

global using AutoMapper.QueryableExtensions;

global using Microsoft.EntityFrameworkCore;
global using WWI.Core6.Services.Interfaces;

global using Serilog;