﻿using System;
using System.Security.Cryptography.X509Certificates;

using Delta.CapiNet.Internals;

namespace Delta.CapiNet
{
    public static class UI
    {
        #region ShowCertificateDialog

        /// <summary>
        /// Shows the certificate dialog loaded with the specified certificate.
        /// </summary>
        /// <remarks>
        /// This method simply wraps <see cref="System.Security.Cryptography.X509Certificates.ShowCertificateDialog"/>.
        /// </remarks>
        /// <param name="certificate">The certificate.</param>
        public static void ShowCertificateDialog(X509Certificate2 certificate)
        {
            ShowCertificateDialog(IntPtr.Zero, certificate);
        }

        /// <summary>
        /// Shows the certificate dialog loaded with the specified certificate.
        /// </summary>
        /// <remarks>
        /// This method simply wraps <see cref="System.Security.Cryptography.X509Certificates.ShowCertificateDialog"/>.
        /// </remarks>
        /// <param name="owner">The owner.</param>
        /// <param name="certificate">The certificate.</param>
        public static void ShowCertificateDialog(IntPtr owner, X509Certificate2 certificate)
        {
            X509Certificate2UI.DisplayCertificate(certificate, owner);
        }

        // Alternate way to show the same dialog
        private static void ShowCertDialog(IntPtr owner, string title, X509Certificate cert)
        {
            NativeMethods.CryptUIDlgViewContext(
                CapiConstants.CERT_STORE_CERTIFICATE_CONTEXT,
                cert.Handle,
                owner,
                title,
                0,
                IntPtr.Zero);
        }

        #endregion

        #region ShowCrlDialog

        public static void ShowCrlDialog(CertificateRevocationList crl)
        {
            ShowCrlDialog(IntPtr.Zero, null, crl);
        }

        public static void ShowCrlDialog(string title, CertificateRevocationList crl)
        {
            ShowCrlDialog(IntPtr.Zero, title, crl);
        }
        public static void ShowCrlDialog(IntPtr owner, CertificateRevocationList crl)
        {
            ShowCrlDialog(owner, null, crl);
        }

        public static void ShowCrlDialog(IntPtr owner, string title, CertificateRevocationList crl)
        {
            NativeMethods.CryptUIDlgViewContext(
                CapiConstants.CERT_STORE_CRL_CONTEXT,
                crl.SafeHandle,
                //crl.Handle,
                owner,
                title,
                0,
                IntPtr.Zero);
        }

        #endregion

        #region ShowCertificatesDialog

        public static void ShowCertificatesDialog()
        {
            ShowCertificatesDialog(IntPtr.Zero);
        }

        public static void ShowCertificatesDialog(IntPtr owner)
        {
            NativeMethods.OpenPersonalTrustDBDialog(owner);
        }

        #endregion

        #region ShowTrustedPublishersDialog

        public static void ShowTrustedPublishersDialog()
        {
            ShowTrustedPublishersDialog(IntPtr.Zero);
        }

        public static void ShowTrustedPublishersDialog(IntPtr owner)
        {
            NativeMethods.OpenPersonalTrustDBDialogEx(
                owner, CapiConstants.WT_TRUSTDBDIALOG_ONLY_PUB_TAB_FLAG, IntPtr.Zero);
        }

        #endregion

        #region ShowBuildCtlWizard (undocumented)

        public static void ShowBuildCtlWizard()
        {
            ShowBuildCtlWizard(IntPtr.Zero, null);
        }

        public static void ShowBuildCtlWizard(string title)
        {
            ShowBuildCtlWizard(IntPtr.Zero, title);
        }

        public static void ShowBuildCtlWizard(IntPtr owner)
        {
            ShowBuildCtlWizard(owner, null);
        }

        public static void ShowBuildCtlWizard(IntPtr owner, string title)
        {
            var h = owner;
            var z = IntPtr.Zero;
            IntPtr returnValue;
            NativeMethods.CryptUIWizBuildCTL(0, h, title, z, z, out returnValue);     // ?
            var rc = returnValue;
        }

        #endregion
    }
}