# QuickSort: sequential vs parallel (Hopac)

```
BenchmarkDotNet=v0.10.5, OS=Windows 10.0.14393
Processor=Intel Core i7-4790K CPU 4.00GHz (Haswell), ProcessorCount=8
Frequency=3906253 Hz, Resolution=255.9998 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
```

|     Method |     Mean |     Error |    StdDev |
|:----------:|:--------:|:---------:|:---------:|
| Sequential | 48.25 ms | 0.1696 ms | 0.1504 ms |
|      Hopac | 24.48 ms | 0.2749 ms | 0.2571 ms |
