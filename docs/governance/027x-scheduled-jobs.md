# 027x – Scheduled Jobs (Oqtane-Enforced)

## Purpose

This rule governs **Scheduled Jobs implemented by Oqtane modules**.

Oqtane **supports scheduled jobs**, but they are **not generic background services**.

All scheduled jobs **must conform exactly*- to Oqtane’s execution, lifecycle, and discovery model.

This rule exists to prevent:

- Improper background processing
- Startup-time side effects
- Cross-tenant state leakage
- Reimplementation of framework infrastructure

---

## Core Principle

> 
> **Modules may define scheduled jobs — but only using Oqtane’s scheduled job architecture.**

Any deviation from the framework-defined pattern is **architecturally invalid**, even if it compiles.

---

## Canonical Reference

Scheduled job behavior is validated against:

- Oqtane Framework scheduled jobs
- Oqtane.Server job execution model
- `HostedServiceBase` implementations in the framework

If a rule conflicts with the Oqtane Framework:

- The framework wins
- The rule must be updated
- AI output must be rejected

---

## Rule 1: Allowed Job Type

A module **may*- implement a scheduled job **only if**:

- It inherits from `HostedServiceBase`
- It resides in the **Server*- project
- It is discovered and executed by Oqtane

**Reject if:**

- `BackgroundService` is used
- `IHostedService` is implemented directly
- Timers, threads, cron jobs, Hangfire, Quartz, or loops are used

---

## Rule 2: Constructor and Scope Management

The job **must**:

- Accept `IServiceScopeFactory` in its constructor
- Pass it to the base `HostedServiceBase` constructor
- Resolve all dependencies *inside- the execution scope

**Reject if:**

- Dependencies are injected directly
- Root or static services are used
- Services are cached across executions

---

## Rule 3: Job Metadata Definition

Scheduling metadata **must*- be defined via public properties:

- `Name`
- `Frequency`
- `Interval`
- `StartDate`
- `EndDate`
- `RetentionHistory`
- `IsEnabled`

These values are consumed by Oqtane during job discovery and execution.

**Reject if:**

- Scheduling logic is implemented elsewhere
- Metadata is hard-coded or inferred
- Execution timing is self-managed

---

## Rule 4: Execution Method

A scheduled job must implement one of:

- `ExecuteJob(IServiceProvider provider)`
- `ExecuteJobAsync(IServiceProvider provider)`

Execution logic **must**:

- Be short-lived
- Be safe to re-run
- Avoid blocking startup
- Avoid long-running loops

**Reject if:**

- The job manages its own lifecycle
- Background threads or delays are created
- Execution assumes single-run behavior

---

## Rule 5: Tenant Safety (Mandatory)

Scheduled jobs execute **once per tenant**.

Job logic must:

- Assume multi-tenant execution
- Avoid static or in-memory shared state
- Never leak data across tenants

**Reject if:**

- Cross-tenant assumptions exist
- Global state is used
- Execution is not tenant-aware

---

## Rule 6: Error Handling and Logging

Jobs must:

- Catch exceptions locally
- Return execution output as a string
- Allow Oqtane to persist job history and logs

**Reject if:**

- Exceptions escape execution
- Custom logging pipelines replace Oqtane logging
- Execution results are discarded

---

## Rule 7: Idempotency

Scheduled jobs **must be idempotent**.

They must not:

- Assume execution order
- Assume execution frequency
- Depend on previous in-memory state

**Reject if:**

- Job behavior changes based on prior execution
- Side effects cannot be safely repeated

---

## Rule 8: Framework-Owned Lifecycle

The following are **owned exclusively by Oqtane*- and must not be reimplemented:

- Job discovery
- Job scheduling
- Execution timing
- Locking
- Persistence
- History retention

**Reject any attempt to override or extend these behaviors.**

---

## Validation Checklist

A scheduled job is valid **only if**:

- It inherits `HostedServiceBase`
- It uses `IServiceScopeFactory`
- Scheduling metadata is defined via properties
- Execution is short-lived and idempotent
- Dependencies are resolved per execution
- Behavior is tenant-safe
- No custom background infrastructure exists

If **any*- check fails, **reject the change**.

---

## Enforcement Statement

This rule is **non-negotiable**.

Scheduled jobs are a **framework feature**, not an extension point for custom infrastructure.

AI must:

- Enforce these constraints
- Refuse non-compliant patterns
- Propose timeline entries when violations are rediscovered

---
