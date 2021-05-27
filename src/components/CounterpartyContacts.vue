<template>
  <q-card flat style="width: 600px;">
    <q-form ref="form" @submit="onSubmit">
      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Email</span>
        <q-input :disable="loading" style="width: 300px" dense filled v-model="form.email" label="Email" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Номер телефона</span>
        <q-input :disable="loading" style="width: 300px" dense filled v-model="form.phone" label="Номер телефона" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Юридический адрес</span>
        <q-input :disable="loading" style="width: 300px" dense filled v-model="form.legalAddress" label="Юридический адрес" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Физический адрес</span>
        <q-input :disable="loading" style="width: 300px" dense filled v-model="form.physicalAddress" label="Физический адрес" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <q-btn type="submit" class="q-ml-auto" :loading="loading" color="primary" label="Сохранить" />
      </q-card-section>
    </q-form>
  </q-card>
</template>

<script>
export default {
  data: () => {
    return {
      loading: false,
      form: {
        legalAddress: null,
        physicalAddress: null,
        email: null,
        phone: null
      }
    }
  },
  props: {
    counterparty: {
      type: Object,
      default: () => null
    }
  },
  created () {
    this.form.legalAddress = this.counterparty.address.legalAddress
    this.form.physicalAddress = this.counterparty.address.physicalAddress
    this.form.email = this.counterparty.contacts.email
    this.form.phone = this.counterparty.contacts.phone
  },
  methods: {
    async onSubmit () {
      this.loading = true

      const form = new FormData()
      for (const key in this.form) {
        form.append(key, this.form[key])
      }
      form.append('tin', this.$route.params.tin)

      try {
        const res = await this.$store.dispatch('counterparty/updateContacts', form)
        if (res.status === 202) {
          this.$q.notify({
            type: 'positive',
            message: 'Контактная инфомация контрагента успешно обновлена.'
          })
        }
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: e.response.statusText
        })
      } finally {
        this.loading = false
      }
    }
  }
}
</script>
