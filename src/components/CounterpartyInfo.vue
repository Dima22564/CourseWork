<template>
  <q-card flat style="width: 600px;">
    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">ИНН</span>
      <q-input readonly :disable="loading" style="width: 300px" dense filled v-model="counterparty.tin" label="ИНН" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">CRTR</span>
      <q-input readonly :disable="loading" style="width: 300px" dense filled v-model="counterparty.crtr" label="CRTR" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Полное название</span>
      <q-input readonly :disable="loading" style="width: 300px" dense filled v-model="counterparty.name.fullName" label="Полное название" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Рабочее название</span>
      <q-input readonly :disable="loading" style="width: 300px" dense filled v-model="counterparty.name.workName" label="Рабочее название" />
    </q-card-section>
  </q-card>
</template>

<script>
export default {
  data: () => {
    return {
      loading: false
    }
  },
  props: {
    counterparty: {
      type: Object,
      default: () => null
    }
  }
}
</script>
