﻿using System;
using NUnit.Framework;
using iOS4Unity;

[TestFixture]
public class NSObjectTests 
{
	[Test]
	public void NewObject()
	{
		var obj = new NSObject();

		Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
		Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
	}

	[Test]
	public void NewObjectDispose()
	{
		var obj = new NSObject();
		obj.Dispose();
	}
}
