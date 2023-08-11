using System;
using BenchmarkDotNet.Attributes;
using Gal.Core;

namespace General.Benchmark
{
    [MemoryDiagnoser()]
    public class Fixed32Benchmark
    {
        private Fixed32[] numberList2;
        private float[] numberList3;

        [GlobalSetup]
        public void Setup() {
            numberList2 = new Fixed32[100];
            numberList3 = new float[100];
            for (var i = 0; i < 100; i++) {
                var v = Random.Shared.Next(int.MinValue, int.MaxValue) / 100f;
                numberList2[i] = v;
                numberList3[i] = v;
            }
        }

        [Benchmark(Baseline = true)]
        public void DoubleArithmetic_Add() {
            var sum = 0d;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList3[i] + numberList3[j];
                }
            }
        }

        [Benchmark()]
        public void Fixed64Arithmetic_Add() {
            var sum = (Fixed32)0;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList2[i] + numberList2[j];
                }
            }
        }

        [Benchmark()]
        public void DoubleArithmetic_Sub() {
            var sum = 0d;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList3[i] - numberList3[j];
                }
            }
        }

        [Benchmark()]
        public void Fixed64Arithmetic_Sub() {
            var sum = (Fixed32)0;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList2[i] - numberList2[j];
                }
            }
        }

        [Benchmark()]
        public void DoubleArithmetic_Mul() {
            var sum = 0d;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList3[i] * numberList3[j];
                }
            }
        }

        [Benchmark()]
        public void Fixed64Arithmetic_Mul() {
            var sum = (Fixed32)0;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList2[i] * numberList2[j];
                }
            }
        }

        [Benchmark()]
        public void DoubleArithmetic_Div() {
            var sum = 0d;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList3[i] / numberList3[j];
                }
            }
        }

        [Benchmark()]
        public void Fixed64Arithmetic_Div() {
            var sum = (Fixed32)0;
            for (var i = 0; i < 100; i++) {
                for (var j = 0; j < 100; j++) {
                    sum += numberList2[i] / numberList2[j];
                }
            }
        }
    }
}