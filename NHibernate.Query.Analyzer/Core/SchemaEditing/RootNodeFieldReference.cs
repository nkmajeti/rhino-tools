﻿#region license
// Copyright (c) 2005 - 2007 Ayende Rahien (ayende@ayende.com)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Ayende Rahien nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion


using System;
using System.Reflection;
using Ayende.NHibernateQueryAnalyzer.Utilities;

namespace Ayende.NHibernateQueryAnalyzer.SchemaEditing
{
	/// <summary>
	/// Summary description for RootFieldReference.
	/// </summary>
	public class RootNodeFieldReference : NodeFieldReference
	{
		private object val;

		public RootNodeFieldReference(object val)
		{
			if(ReflectionUtil.HasValue(val)==false)
				throw new ArgumentException("Val must have a valid value.");
			this.val = val;
			this.amountRequired = 1;
		}

		public override string[] Names
		{
			get { throw new InvalidOperationException("Root has no names"); }
		}

		public override Type[] Types
		{
			get { throw new InvalidOperationException("Root has no types");; }
		}

		public override object Value
		{
			get { return val; }
			set { throw new InvalidOperationException("Can't set root's value, it's immutable"); }
		}

		/// <summary>
		/// Return true if the inner value is an array with 
		/// elements or a non-null reference.
		/// </summary>
		public override bool HasValue
		{
			get { return true; }
		}

		public override ISchemaEditorNode ParentNode
		{
			get { return parentNode; }
			set { parentNode = value; }
		}

		public override ISchemaEditorNode AddValue(object obj)
		{
			throw new InvalidOperationException("Can't add value to root node");			
		}

		public override ISchemaEditorNode AddExistingValue(object obj)
		{
			throw new InvalidOperationException("Can't add value to root node");			
		}

		public override void RemoveValue(ISchemaEditorNode node)
		{
			throw new InvalidOperationException("Can't remove value from root node");
		}
	}
}