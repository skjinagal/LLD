// See https://aka.ms/new-console-template for more information
using LRU;
Console.WriteLine("LRU Cache!");
var lruCache = new LRU.LRU (5);
lruCache.Put(1, 1);
lruCache.Put(2, 2);
lruCache.Put(3, 3);
lruCache.Put(4, 4);
lruCache.DisplayCache();
lruCache.Get(2);
lruCache.DisplayCache();
lruCache.Put(5, 5);
lruCache.DisplayCache();
lruCache.Put(6, 6);
lruCache.DisplayCache();
