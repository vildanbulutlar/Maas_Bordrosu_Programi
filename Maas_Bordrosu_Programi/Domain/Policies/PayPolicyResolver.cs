using Maas_Bordrosu_Programi.Domain.Policies.Implementations;
using System;
using System.Collections.Concurrent;

namespace Maas_Bordrosu_Programi.Domain.Policies
{
    public static class PayPolicyResolver
    {
        private static readonly ConcurrentDictionary<string, BasePayPolicy> Map =
            new(StringComparer.OrdinalIgnoreCase);

        private static readonly BasePayPolicy Fallback = new DefaultPayPolicy();

        static PayPolicyResolver()
        {
            Map["Yonetici"] = new ManagerPayPolicy();
            Map["Memur"] = new ClerkPayPolicy();
        }

        public static BasePayPolicy Resolve(string? title) =>
            Map.TryGetValue(title ?? string.Empty, out var p) ? p : Fallback;

        public static void Register(string title, BasePayPolicy policy) => Map[title] = policy;
    }
}