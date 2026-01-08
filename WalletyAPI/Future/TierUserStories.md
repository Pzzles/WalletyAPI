🧩 EPIC: Tier & Account Survivability

Goal:
Tier controls account survivability and recovery strength, not spending behaviour.

🔴 TIER-01 — Default Tier Assignment (Foundational)

As a system
I want every new user to start in the safest possible tier
So that account capture risk is minimised by default

Acceptance Criteria

All new users are created with:

Tier = Assisted

Tier is non-nullable

Tier is system-controlled

Tier cannot be set by the client at signup

🔴 TIER-02 — Tier Qualification via Auth Channels

As a system
I want to determine a user’s tier based on available authentication channels
So that recovery strength matches account capabilities

Acceptance Criteria

User with phone number only → Tier = Assisted

User with phone + verified email → eligible for Tier = Independent

Email must be verified before tier eligibility

Tier is not automatically upgraded without explicit action

🔴 TIER-03 — Tier Upgrade to Independent

As a user
I want to upgrade my tier by adding a verified email
So that my account becomes more resilient

Acceptance Criteria

User can add an email address

Email must be verified

On successful verification:

Tier transitions from Assisted → Independent

Tier change is immediate

Tier change is recorded in audit log

🔴 TIER-04 — Voluntary Tier Downgrade

As a user
I want to downgrade myself to Assisted tier
So that my account has reduced attack surface

Acceptance Criteria

Independent users can voluntarily downgrade to Assisted

Downgrade is immediate

Email remains stored but is excluded from auth-critical flows

Tier downgrade reason is recorded

No system features break due to downgrade

🟠 TIER-05 — Tier Change Auditability

As a system
I want all tier changes to be auditable
So that security events can be investigated

Acceptance Criteria

Every tier change records:

Previous tier

New tier

Timestamp

Initiator (system / user / guardian)

Reason

Audit records are immutable

Tier history is queryable by admins only

🟠 TIER-06 — Guardian Association Eligibility

As a system
I want only sufficiently resilient users to act as guardians
So that recovery paths are reliable

Acceptance Criteria

Only Independent tier users can:

Become guardians

Assisted users:

Can have guardians

Cannot act as guardians

Guardian assignment checks tier at assignment time

🟠 TIER-07 — Tier-Aware Recovery Behaviour

As a system
I want recovery flows to behave differently by tier
So that account capture is detected early

Acceptance Criteria

Assisted tier:

Phone number is primary recovery path

Guardian alerts are triggered on critical changes

Independent tier:

Email is used for alerts and recovery

Recovery channel downgrade triggers alerts

🟡 TIER-08 — Tier Integrity Enforcement

As a system
I want to prevent invalid tier states
So that the security model cannot drift

Acceptance Criteria

Independent tier requires:

Verified email

If verified email is removed or invalidated:

Tier automatically reverts to Assisted

Tier integrity is enforced server-side only

🟡 TIER-09 — Tier Exposure to Client

As a user
I want to see my current tier
So that I understand my account posture

Acceptance Criteria

API exposes current tier (read-only)

Tier explanation is human-readable

No internal logic is exposed

🚫 Explicit Non-Goals (Important)

These are intentionally excluded:

❌ Tier does NOT affect transaction execution

❌ Guardians do NOT approve transactions

❌ Tier does NOT block P2P or cashout

❌ Tier does NOT protect users from bad decisions

This is by design and matches the document.

Where You Are Now

You can now safely implement:

Tier persistence

Tier transitions

Tier guards

Guardian eligibility checks

Nothing here conflicts with your transaction model.

Next step (your call):

Reply with:

“Transactions now” → I’ll do transaction user stories

“Guardians next” → we formalise guardian behaviour

“Audit & alerts” → system integrity layer

You’re building this the right way.