using System;

namespace flowsimulator {
    /// <summary>
    /// Summary description for InvalidValueSpecificationException.
    /// </summary>
    public class InvalidValueSpecificationException : Exception {
        public InvalidValueSpecificationException(string spec)
            : base(spec) {
        }
    }
}
