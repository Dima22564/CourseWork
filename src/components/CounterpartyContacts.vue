<template>
  <q-card flat style="width: 600px;">
    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Email</span>
      <q-input :disable="loading" style="width: 300px" dense filled v-model="email" label="Email" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Номер телефона</span>
      <q-input :disable="loading" style="width: 300px" dense filled v-model="phone" label="Номер телефона" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Юридический адрес</span>
      <q-input :disable="loading" style="width: 300px" dense filled v-model="legalAddress" label="Юридический адрес" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Физический адрес</span>
      <q-input :disable="loading" style="width: 300px" dense filled v-model="physicalAddress" label="Физический адрес" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <q-btn class="q-ml-auto" :loading="loading" color="primary" label="Сохранить" />
    </q-card-section>
  </q-card>
</template>

<script>
export default {
  data: () => {
    return {
      loading: false,
      legalAddress: null,
      PhysicalAddress: null,
      email: null,
      phone: null
    }
  }
}
</script>
