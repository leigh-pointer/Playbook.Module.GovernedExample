# 027x – AI Decision Timeline (Enforced)

This rule governs the use of the **AI Decision Timeline** as a binding
governance artifact.

The timeline exists to prevent repeated rediscovery of framework invariants,
invalid patterns, and previously rejected approaches.

---

## Rule 1: Timeline Is Binding Governance

The AI Decision Timeline is treated as **authoritative historical context**.

AI must not:
- Reintroduce rejected patterns
- Re-argue resolved decisions
- Ignore recorded invariants

If a conflict exists between:
- AI output
- Current request
- Timeline entries

**The timeline wins.**

---

## Rule 2: Mandatory Timeline Review

Before responding to any **non-trivial** request, AI must:

- Read `docs/ai-decision-timeline.md`
- Identify any related past decisions
- Apply recorded constraints

If the timeline is not visible:
- AI must refuse to proceed

---

## Rule 3: When a Timeline Entry Is Required

A timeline entry must be proposed when:

- AI output was plausible but incorrect
- A framework invariant was rediscovered
- A request required multiple correction iterations
- A request was refused due to governance constraints

Trivial fixes must NOT be recorded.

---

## Rule 4: Append-Only Enforcement

AI may:

- Propose new timeline entries
- Append entries in the approved format

AI must NOT:

- Modify existing entries
- Delete entries
- Reorder entries
- Reinterpret past decisions

Violations invalidate the output.

---

## Rule 5: Timeline Visibility Requirement

The timeline must be:

- File-backed
- Repository-visible
- Included in the solution context

If the file exists but is not visible to AI:
- It is treated as nonexistent
- AI must refuse and explain why

---

## Enforcement

If this rule applies and is violated:

- Output must be rejected
- No best-effort correction is allowed
- Governance integrity takes precedence over task completion
