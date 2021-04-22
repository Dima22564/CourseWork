<template>
  <q-card flat style="width: 600px;">
    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Номер</span>
      <q-input readonly style="width: 300px" dense filled v-model="businessProposal.name" label="Номер" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">От</span>
      <q-input readonly style="width: 300px" dense filled v-model="businessProposal.from" label="От" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Действительно с</span>
      <q-input readonly style="width: 300px" dense filled v-model="businessProposal.validFrom" label="Действительно с" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Действительно до</span>
      <q-input readonly style="width: 300px" dense filled v-model="businessProposal.validTo" label="Действительно до" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Компания</span>
      <q-input readonly style="width: 300px" dense filled v-model="businessProposal.company" label="Компания" />
    </q-card-section>
  </q-card>
</template>

<script>
export default {
  name: 'BusinessProposalInfo',
  props: {
    businessProposal: {
      type: Object,
      default: () => {
        return {}
      }
    }
  }
}
</script>
