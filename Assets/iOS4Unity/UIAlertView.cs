﻿using System;

namespace iOS4Unity
{
    public class UIAlertView : NSObject
    {
        private static readonly IntPtr _classHandle;

        static UIAlertView()
        {
            _classHandle = ObjC.GetClass("UIAlertView");
        }

        public override IntPtr ClassHandle
        {
            get { return _classHandle; }
        }

        public UIAlertView()
        {
            Handle = ObjC.MessageSendIntPtr(Handle, "init");
            ObjC.MessageSend(Handle, "setDelegate:", Handle);
        }

        internal UIAlertView(IntPtr handle)
            : base(handle)
        {
        }

        public event EventHandler<ButtonEventArgs> Clicked
        {
            add { Callbacks.Subscribe(this, "alertView:clickedButtonAtIndex:", value); }
            remove { Callbacks.Unsubscribe(this, "alertView:clickedButtonAtIndex:", value); }
        }

        public event EventHandler<ButtonEventArgs> Dismissed
        {
            add { Callbacks.Subscribe(this, "alertView:didDismissWithButtonIndex:", value); }
            remove { Callbacks.Unsubscribe(this, "alertView:didDismissWithButtonIndex:", value); }
        }

        public event EventHandler<ButtonEventArgs> WillDismiss
        {
            add { Callbacks.Subscribe(this, "alertView:willDismissWithButtonIndex:", value); }
            remove { Callbacks.Unsubscribe(this, "alertView:willDismissWithButtonIndex:", value); }
        }

        public event EventHandler Canceled
        {
            add { Callbacks.Subscribe(this, "alertViewCancel:", value); }
            remove { Callbacks.Unsubscribe(this, "alertViewCancel:", value); }
        }

        public event EventHandler Presented
        {
            add { Callbacks.Subscribe(this, "didPresentAlertView:", value); }
            remove { Callbacks.Unsubscribe(this, "didPresentAlertView:", value); }
        }

        public event EventHandler WillPresent
        {
            add { Callbacks.Subscribe(this, "willPresentAlertView:", value); }
            remove { Callbacks.Unsubscribe(this, "willPresentAlertView:", value); }
        }

        public UIAlertViewStyle AlertViewStyle
        {
            get { return (UIAlertViewStyle)ObjC.MessageSendInt(Handle, "alertViewStyle"); }
            set { ObjC.MessageSend(Handle, "setAlertViewStyle:", (int)value); }
        }

        public int AddButton(string title)
        {
            return ObjC.MessageSendInt(Handle, "addButtonWithTitle:", title);
        }

        public int ButtonCount
        {
            get { return ObjC.MessageSendInt(Handle, "numberOfButtons"); }
        }

        public int CancelButtonIndex
        {
            get { return ObjC.MessageSendInt(Handle, "cancelButtonIndex"); }
            set { ObjC.MessageSend(Handle, "setCancelButtonIndex:", value); }
        }

        public int FirstOtherButtonIndex
        {
            get { return ObjC.MessageSendInt(Handle, "firstOtherButtonIndex"); }
        }

        public string ButtonTitle(int index)
        {
            return ObjC.MessageSendString(Handle, "buttonTitleAtIndex:", index);
        }

        public bool Visible
        {
            get { return ObjC.MessageSendBool(Handle, "isVisible"); }
        }

        public string Message
        {
            get { return ObjC.MessageSendString(Handle, "message"); }
            set { ObjC.MessageSend(Handle, "setMessage:", value); }
        }

        public string Title
        {
            get { return ObjC.MessageSendString(Handle, "title"); }
            set { ObjC.MessageSend(Handle, "setTitle:", value); }
        }

        public void Show()
        {
            ObjC.MessageSend(Handle, "show");
        }

        public void Dismiss(int buttonIndex, bool animated = true)
        {
            ObjC.MessageSend(Handle, "dismissWithClickedButtonIndex:animated:", buttonIndex, animated);
        }
    }

    public enum UIAlertViewStyle
    {
        Default,
        SecureTextInput,
        PlainTextInput,
        LoginAndPasswordInput
    }
}