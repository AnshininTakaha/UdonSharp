﻿using System;
using Microsoft.CodeAnalysis;
using UdonSharp.Compiler.Symbols;

namespace UdonSharp.Compiler
{
    /// <summary>
    /// Base representation of a phase of compilation
    /// </summary>
    internal abstract class AbstractPhaseContext
    {
        public CompilationContext CompileContext { get; }

        protected AbstractPhaseContext(CompilationContext compileContext)
        {
            CompileContext = compileContext;
        }
        
        public TypeSymbol GetTypeSymbol(ITypeSymbol type)
        {
            var typeSymbol = CompileContext.GetTypeSymbol(type, this);
            OnSymbolRetrieved(typeSymbol);

            return typeSymbol;
        }

        public TypeSymbol GetUdonTypeSymbol(ITypeSymbol type)
        {
            var typeSymbol = CompileContext.GetUdonTypeSymbol(type, this);
            OnSymbolRetrieved(typeSymbol);

            return typeSymbol;
        }

        public TypeSymbol GetTypeSymbol(Type systemType)
        {
            var typeSymbol = CompileContext.GetTypeSymbol(systemType, this);
            OnSymbolRetrieved(typeSymbol);

            return typeSymbol;
        }

        public TypeSymbol GetTypeSymbol(SpecialType type)
        {
            var typeSymbol = CompileContext.GetTypeSymbol(type, this);
            OnSymbolRetrieved(typeSymbol);

            return typeSymbol;
        }

        public Symbol GetSymbol(ISymbol sourceSymbol)
        {
            var symbol = CompileContext.GetSymbol(sourceSymbol, this);
            OnSymbolRetrieved(symbol);

            return symbol;
        }

        public void MarkSymbolReferenced(Symbol symbol)
        {
            OnSymbolRetrieved(symbol);
        }

        protected virtual void OnSymbolRetrieved(Symbol symbol)
        {
        }
    }
}
