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
using System.Collections.Generic;
using MbUnit.Framework;

namespace Rhino.Mocks.Tests.FieldsProblem
{
	[TestFixture]
	public class FieldProblem_James
	{
		private MockRepository m_mockery;

		[SetUp]
		public void Setup()
		{
			m_mockery = new MockRepository();
		}

		[Test]
		public void ShouldBeAbleToMockGenericMethod()
		{
			ILookupMapper<int> mapper = m_mockery.CreateMock<ILookupMapper<int>>();
			List<Foo<int>> retval = new List<Foo<int>>();
			retval.Add(new Foo<int>());
			Expect.Call(mapper.FindAllFoo()).Return(retval);
			m_mockery.ReplayAll();
			IList<Foo<int>> listOfFoo = mapper.FindAllFoo();
			m_mockery.VerifyAll();
		}

		[Test]
		public void ShouldBeAbleToMockGenericMethod2()
		{
			ILookupMapper<int> mapper = m_mockery.CreateMock<ILookupMapper<int>>();
			Foo<int> retval = new Foo<int>();
			Expect.Call(mapper.FindOneFoo()).Return(retval);
			m_mockery.ReplayAll();
			Foo<int> oneFoo = mapper.FindOneFoo();
			m_mockery.VerifyAll();
		}

//		This is a compiler error now
//		[Test]
//		[ExpectedException(typeof(InvalidOperationException),"Type 'Rhino.Mocks.Tests.FieldsProblem.Foo`1[[System.String, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]' doesn't match the return type 'Rhino.Mocks.Tests.FieldsProblem.Foo`1[System.Int32]' for method 'ILookupMapper`1.FindOneFoo();'")]
//		public void ShouldGetValidErrorWhenGenericTypeMismatchOccurs()
//		{
//			ILookupMapper<int> mapper = m_mockery.CreateMock<ILookupMapper<int>>();
//			Foo<string> retval = new Foo<string>();
//			Expect.Call(mapper.FindOneFoo()).Return(retval);
//		}
	}

	public interface ILookupMapper<T>
	{
		IList<Foo<T>> FindAllFoo();
		Foo<T> FindOneFoo();
	}

	public class Foo<T>
	{
		public T GetOne()
		{
			return default(T);
		}
	}
}