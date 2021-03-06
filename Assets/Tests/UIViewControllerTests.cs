﻿using iOS4Unity;
using NUnit.Framework;
using System;

#if !UNITY_EDITOR

[TestFixture]
public class UIViewControllerTests
{
    [Test]
    public void NewObject()
    {
        var obj = new UIViewController();

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new UIViewController();
        obj.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new UIViewController();
        var b = Runtime.GetNSObject<UIViewController>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void ObjectSameRootController()
    {
        var window = UIApplication.SharedApplication.KeyWindow;
        var a = window.RootViewController;
        var b = window.RootViewController;
        Assert.AreSame(a, b);
    }

    [Test]
    public void Title()
    {
        string text = "MyTitle";
        var controller = new UIViewController();
        controller.Title = text;
        Assert.AreEqual(text, controller.Title);
    }

    [Test]
    public void View()
    {
        var view = new UIViewController().View;
        Assert.IsNotNull(view);
        Assert.AreNotEqual(IntPtr.Zero, view.Handle);
    }

    [Test]
    public void LoadView()
    {
        new UIViewController().LoadView();
    }

    [Test]
    public void IsViewLoaded()
    {
        var controller = new UIViewController();
        controller.LoadView();
        Assert.IsTrue(controller.IsViewLoaded);
    }
}

#endif