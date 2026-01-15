# Localization Opt-In Prompt (Copilot / AI Prompt)

This is designed to be explicit, activating, and non-ambiguous.

## **Short Version (most practical)**

```text
This module requires full localization support.

Apply the 027x-localization rule:
- All user-facing strings must be localized
- Use IStringLocalizer<T> following canonical Oqtane patterns
- Do not mix hardcoded and localized strings
- Validate against Oqtane framework localization usage
```

## **Explicit Activation Version (best for first use)**

```text
Localization is intentionally enabled for this module.

You MUST apply the 027x-localization governance rule.

This means:
- All user-facing text must be localized
- Use IStringLocalizer<T> or equivalent canonical Oqtane patterns
- No hardcoded UI strings are permitted
- No partial or mixed localization is allowed
- Validate behavior against Oqtane framework modules

If any localization rule cannot be followed, you must stop and explain why.
```

## **Defensive / Governance-Safe Version (maximum correctness)**

```text
This module opts in to localization.

Activate and enforce 027x-localization.md.

Once active:
- Every user-facing string must be localized
- Localization must follow canonical Oqtane framework patterns
- Mixed localized and non-localized UI is forbidden
- If compliance is not possible, refuse and explain

Do not invent localization approaches.
```