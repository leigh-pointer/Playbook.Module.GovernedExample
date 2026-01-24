# AI Assistant Instructions — Oqtane AI Governance

If governance files are not visible, you must refuse to proceed and explain why.

## Governance Source and Authority

This repository follows the **Oqtane AI Playbook** governance model.

The playbook defines framework invariants, architectural constraints,
and AI enforcement rules for safe Oqtane module development.

## Canonical Reference Source

The **canonical reference** for this repository is the **Oqtane Framework source code**
referenced by this module.

This includes, but is not limited to:

- Oqtane.Client
- Oqtane.Server
- Oqtane.Shared
- Oqtane.Infrastructure
- Framework modules (e.g. HtmlText)
- Built-in Scheduled Jobs
- Built-in Migrations
- Built-in Validation and Error Handling patterns

These sources collectively represent the **single point of truth** for correct Oqtane architecture and behavior.

When generating or modifying code, I must:

- Inspect the referenced Oqtane Framework code first
- Validate behavior against existing framework implementations
- Treat framework patterns as **authoritative**
- Reject output that deviates from demonstrated Oqtane patterns

Canonical validation is performed against the Oqtane Framework source
(Oqtane.Client, Oqtane.Server, Oqtane.Shared, and internal framework modules).

If a non-trivial correction is made, propose a timeline entry.

---

## Architectural Constraints

You MUST NOT:

- Invent architectural patterns
- Introduce `@page` routing in modules
- Introduce role-based authorization
- Add or modify `Program.cs`, `Startup.cs`, or global DI
- Assume control of application startup
- Register services outside `IClientStartup` or `IServerStartup`
- Replace explicit logic with abstractions

---

## Service Registration Rules

- Client services → `IClientStartup`
- Server services → `IServerStartup`
- Client/server boundaries are strict and non-crossing
- Generic ASP.NET Core startup patterns are invalid

---

## Debugging & Analysis Rules

When debugging:

1. Validate transport first (JSON vs HTML)
2. Validate HTTP status
3. Validate authorization & middleware
4. Only then inspect application logic

If HTML is returned where JSON is expected:
- STOP
- Diagnose boundary or pipeline violation

---

## AI Decision Timeline

Before responding to non-trivial questions:
- CHECK `/docs/ai-decision-timeline.md`
- Do not reintroduce previously rejected patterns
- If a new invariant is discovered, recommend adding a timeline entry

### AI Decision Timeline Authority

The file `docs/ai-decision-timeline.md` is a governed artifact.

The AI is explicitly authorized to:
- Append new entries to the timeline
- Only when a request is refused, corrected after multiple iterations, or reveals a framework invariant
- Never modify or delete existing entries

When such a situation occurs, the AI MUST:
1. Draft a timeline entry using the canonical format
2. Append it under the Timeline section
3. Acknowledge the entry in its response
---

## Response Expectations

- Be explicit
- Be deterministic
- Do not assume intent
- Prefer rejection over “best effort” fixes

If unsure, ask for clarification **without inventing behavior**.

If an issue appears in docs/ai-decision-timeline.md, it is considered resolved and must not be re-litigated.

---

## Governance Rule Creation Constraint

You are NOT permitted to invent or introduce new governance rules.

If a request implies a missing rule or unclear constraint, you MUST:

1. Check docs/ai-decision-timeline.md
2. Determine whether the issue is already recorded
3. Propose a Governance Rule Proposal instead of generating code

You may summarize a proposed rule but must not enforce it unless it exists in 027-ai-governance.md.