<a name="title" />
# Redis Cache #

---
<a name="Overview" />
## Overview ##

This demo shows the benefits of using Redis for an index cache lookup.

<a name="Setup" />
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. None

<a name="Demo" />
## Demo ##

1. Run the application.
1. Check the "Directly Search Table" checkbox.
1. Type a capital letter in the search field and click search. While the search is running (takes roughly 25 seconds) explain that the application is querying against 1 million un-indexed rows in table storage.
1. Uncheck the "Directly Search Table" checkbox and run the search again. Search completes in under 2 seconds because it's querying against an indexed Redis cache.

---

<a name="summary" />
## Summary ##

By completing this demo you have shown the performance impact of querying against a fast cache.

---
